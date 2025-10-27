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
    public class ModoPreparoConsultaRepositorio : IModoPreparoConsultaRepositorio
    {
        private readonly IConfiguration _configuration;

        public ModoPreparoConsultaRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<ModoPreparoDto>> ObterListarModoPreparo()
        {
            var supabaseUrl = _configuration["SupabaseUrl"];
            var supabaseKey = _configuration["SupabaseKey"];

            var client = new Client(supabaseUrl!, supabaseKey);

            await client.InitializeAsync();

            var modoPreparo = await client.From<ModoPreparo>().Get();

            return modoPreparo.Models.Select(m => new ModoPreparoDto
            {
                IdPreparo = m.IdPreparo,
                IdReceita = m.IdReceita,
                DataCriacao = m.DataCriacao,
                QtdeEtapas = m.QtdeEtapas,
                InstrucoesPreparo = m.InstrucoesPreparo.Select(i => new Dominio.DTOs.ModoPreparoItem { Etapa = i.Etapa, Descricao = i.Descricao }).ToList(),
                Ingredientes = m.Ingredientes.Select(i => new Dominio.DTOs.IngredienteItem { Nome = i.Nome, Quantidade = i.Quantidade }).ToList(),
                Tempo = m.Tempo
            });
        }

        public async Task<ModoPreparoDto> ObterModoPreparoPorIdReceita(int idReceita)
        {
            var supabaseUrl = _configuration["SupabaseUrl"];
            var supabaseKey = _configuration["SupabaseKey"];

            var client = new Client(supabaseUrl!, supabaseKey);

            await client.InitializeAsync();

            var modoPreparo = await client.From<ModoPreparo>().Where(m => m.IdReceita == idReceita).Get();

            var mModel = modoPreparo.Models.FirstOrDefault();

            return new ModoPreparoDto
            {
                IdPreparo = mModel.IdPreparo,
                IdReceita = mModel.IdReceita,
                DataCriacao = mModel.DataCriacao,
                QtdeEtapas = mModel.QtdeEtapas,
                InstrucoesPreparo = mModel.InstrucoesPreparo.Select(i => new Dominio.DTOs.ModoPreparoItem { Etapa = i.Etapa, Descricao = i.Descricao }).ToList(),
                Ingredientes = mModel.Ingredientes.Select(i => new Dominio.DTOs.IngredienteItem { Nome = i.Nome, Quantidade = i.Quantidade }).ToList(),
                Tempo = mModel.Tempo
            };
        }
    }
}
