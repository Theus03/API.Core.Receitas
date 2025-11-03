using Microsoft.Extensions.Configuration;
using Receitas.Dominio.DTOs;
using Receitas.Dominio.Entidades;
using Receitas.Dominio.Requests;
using Supabase;
using Supabase.Interfaces;
using Supabase.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Repositorio.Comandos
{
    public class ReceitasComandosRepositorio : IReceitasComandosRepositorio
    {
        private readonly IConfiguration _configuration;

        public ReceitasComandosRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ReceitaDto> InserirReceita(InserirReceitaRequest receita)
        {
            var supabaseUrl = _configuration["supabaseUrl"];
            var supabaseKey = _configuration["supabaseKey"];
            var bucket = _configuration["supabaseBucket"];

            var client = new Supabase.Client(supabaseUrl!, supabaseKey);
            await client.InitializeAsync();

            string imagemUrl = string.Empty;

            if (receita.Imagem != null) {
                imagemUrl = InserirImagemReceita(receita, client, bucket!);
            }

            Receita novaReceita = new Receita
            {
                IdTipoReceita = receita.IdTipoReceita,
                DataCriacao = DateTime.UtcNow,
                Nome = receita.Nome,
                Imagem = imagemUrl
            };

            var response = await client.From<Receita>().Insert(novaReceita);

            return response.Models.Select(r => new ReceitaDto
            {
                IdReceita = r.IdReceita,
                IdTipoReceita = r.IdTipoReceita,
                DataCriacao = r.DataCriacao,
                Nome = r.Nome,
                Imagem = r.Imagem ?? null
            }).FirstOrDefault()!;
        }


        public async Task<TiposReceitaDto> InserirTipoReceita(TiposReceitaDto tipoReceita)
        {
            var supabaseUrl = _configuration["supabaseUrl"];
            var supabaseKey = _configuration["supabaseKey"];

            var client = new Supabase.Client(supabaseUrl!, supabaseKey);

            await client.InitializeAsync();

            TiposReceita novoTipoReceita = new TiposReceita
            {
                DataCriacao = DateTime.UtcNow,
                TipoReceita = tipoReceita.TipoReceita
            };

            var response = await client.From<TiposReceita>().Insert(novoTipoReceita);

            return response.Models.Select(r => new TiposReceitaDto
            {
                IdTipoReceita = r.IdTipoReceita,
                DataCriacao = r.DataCriacao,
                TipoReceita = r.TipoReceita
            }).FirstOrDefault()!;
        }

        public string InserirImagemReceita(InserirReceitaRequest receita, Supabase.Client client, string bucket)
        {
            byte[] bytes;
            using (var ms = new MemoryStream())
            {
                receita.Imagem!.CopyToAsync(ms);
                bytes = ms.ToArray();
            }

            var storage = client.Storage.From(bucket!);

            string fileName = $"{Guid.NewGuid()}_{receita.Imagem!.FileName}";

            storage!.Upload(bytes, fileName, new Supabase.Storage.FileOptions { ContentType = receita.Imagem.ContentType });

            string imagemUrl = storage.GetPublicUrl(fileName);

            return imagemUrl;
        }
    }
}
