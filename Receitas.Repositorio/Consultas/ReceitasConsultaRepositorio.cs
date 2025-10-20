using Microsoft.Extensions.Configuration;
using Receitas.Dominio.DTOs;
using Receitas.Dominio.Entidades;
using Supabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Repositorio.Consultas
{
    public class ReceitasConsultaRepositorio : IReceitasConsultaRepositorio
    {
        private readonly IConfiguration _configuration;

        public ReceitasConsultaRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<ReceitaDto>> ObterReceitas()
        {

            var supabaseUrl = _configuration["SupabaseUrl"];
            var supabaseKey = _configuration["SupabaseKey"];

            var client = new Client(supabaseUrl!, supabaseKey);

            await client.InitializeAsync();

            var receitas = await client.From<Receita>().Get();

            return receitas.Models.Select(r => new ReceitaDto
            {
                IdReceita = r.IdReceita,
                IdTipoReceita = r.IdTipoReceita,
                DataCriacao = r.DataCriacao,
                Nome = r.Nome
            });
        }

        public async Task<ReceitaDto> ObterReceitaPorId(int id)
        {
            var supabaseUrl = _configuration["SupabaseUrl"];
            var supabaseKey = _configuration["SupabaseKey"];

            var client = new Client(supabaseUrl!, supabaseKey);

            await client.InitializeAsync();
            
            var receita = await client.From<Receita>().Where(r => r.IdReceita == id).Get();
            
            var rModel = receita.Models.FirstOrDefault();

            return new ReceitaDto
            {
                IdReceita = rModel?.IdReceita,
                IdTipoReceita = rModel?.IdTipoReceita,
                DataCriacao = rModel?.DataCriacao,
                Nome = rModel?.Nome
            };
        }

        public async Task<IEnumerable<TiposReceitaDto>> ObterTiposReceitas()
        {
            var supabaseUrl = _configuration["SupabaseUrl"];
            var supabaseKey = _configuration["SupabaseKey"];

            var client = new Client(supabaseUrl!, supabaseKey);

            await client.InitializeAsync();

            var tiposReceitas = await client.From<TiposReceita>().Get();

            var qtdeTipoPorReceita = await client.From<Receita>().Where(r => r.IdTipoReceita != null).Get();

            return tiposReceitas.Models.Select(t => new TiposReceitaDto
            {
                IdTipoReceita = t.IdTipoReceita,
                DataCriacao = t.DataCriacao,
                TipoReceita = t.TipoReceita,
                QuantidadeReceitas = qtdeTipoPorReceita.Models.Where(r => r.IdTipoReceita == t.IdTipoReceita).Count()
            });
        }
    }
}
