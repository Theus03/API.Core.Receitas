using Microsoft.Extensions.Configuration;
using Receitas.Dominio.DTOs;
using Receitas.Dominio.Entidades;
using Receitas.Dominio.Requests;
using Receitas.Repositorio.Conexao;
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
        private readonly IContextDB _contextDB;
        private Supabase.Client client;

        public ReceitasComandosRepositorio(IConfiguration configuration, IContextDB contextDB)
        {
            _configuration = configuration;
            _contextDB = contextDB;
            client = _contextDB.ObterConexao().Result;
        }

        public async Task<ReceitaDto> InserirReceita(Receita receita)
        {
            var response = await client.From<Receita>().Insert(receita);

            return response.Models.Select(r => new ReceitaDto
            {
                IdReceita = r.IdReceita,
                IdTipoReceita = r.IdTipoReceita,
                DataCriacao = r.DataCriacao,
                Nome = r.Nome,
                Imagem = r.Imagem
            }).FirstOrDefault()!;
        }


        public async Task<TiposReceitaDto> InserirTipoReceita(TiposReceitaDto tipoReceita)
        {
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

        public string InserirImagemReceita(InserirReceitaRequest receita)
        {
            byte[] bytes;

            var bucket = _configuration["supabaseBucket"];

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
