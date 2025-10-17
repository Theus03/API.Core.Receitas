using Microsoft.Extensions.Configuration;
using Receitas.Dominio.DTOs;
using Receitas.Dominio.Entidades;
using Supabase;
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
        
        public async Task<ReceitaDto> InserirReceita(ReceitaDto receita)
        {
            var supabaseUrl = _configuration["supabaseUrl"];
            var supabaseKey = _configuration["supabaseKey"];

            var client = new Client(supabaseUrl!, supabaseKey);

            await client.InitializeAsync();

            Receita novaReceita = new Receita
            {
                IdTipoReceita = receita.IdTipoReceita,
                DataCriacao = DateTime.UtcNow,
                Nome = receita.Nome
            };

            var response  = await client.From<Receita>().Insert(novaReceita);

            return response.Models.Select(r => new ReceitaDto
            {
                IdReceita = r.IdReceita,
                IdTipoReceita = r.IdTipoReceita,
                DataCriacao = r.DataCriacao,
                Nome = r.Nome
            }).FirstOrDefault()!;

        }

        public async Task<TiposReceitaDto> InserirTipoReceita(TiposReceitaDto tipoReceita)
        {
            var supabaseUrl = _configuration["supabaseUrl"];
            var supabaseKey = _configuration["supabaseKey"];

            var client = new Client(supabaseUrl!, supabaseKey);

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
    }
}
