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

            var response = await client.From<Receita>().Get();

            return response.Models.Select(r => new ReceitaDto
            {
                IdReceita = r.IdReceita,
                IdTipoReceita = r.IdTipoReceita,
                DataCriacao = r.DataCriacao,
                Nome = r.Nome
            });
        }
    }
}
