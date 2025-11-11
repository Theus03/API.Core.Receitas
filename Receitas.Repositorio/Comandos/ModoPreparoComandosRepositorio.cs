using Microsoft.Extensions.Configuration;
using Receitas.Dominio.DTOs;
using Receitas.Dominio.Entidades;
using Receitas.Repositorio.Conexao;
using Supabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Repositorio.Comandos
{
    public class ModoPreparoComandosRepositorio : IModoPreparoComandosRepositorio
    {
        private readonly IConfiguration _configuration;
        private readonly IContextDB _contextDB;

        public ModoPreparoComandosRepositorio(IConfiguration configuration, IContextDB contextDB)
        {
            _configuration = configuration;
            _contextDB = contextDB;
        }

        public async Task<ModoPreparoDto> InserirModoPreparo(ModoPreparoDto modoPreparo)
        {

            Client client = await _contextDB.ObterConexao();

            ModoPreparo novoModoPreparo = new ModoPreparo
            {
                IdPreparo = modoPreparo.IdPreparo,
                DataCriacao = modoPreparo.DataCriacao,
                IdReceita = modoPreparo.IdReceita,
                QtdeEtapas = modoPreparo.QtdeEtapas,
                InstrucoesPreparo = modoPreparo.InstrucoesPreparo.Select(m => new Dominio.Entidades.ModoPreparoItem { Etapa = m.Etapa, Descricao = m.Descricao }).ToList(),
                Ingredientes = modoPreparo.Ingredientes.Select(i => new Dominio.Entidades.IngredienteItem { Nome = i.Nome, Quantidade = i.Quantidade }).ToList(),
                Tempo = modoPreparo.Tempo
            };

            var response = await client.From<ModoPreparo>().Insert(novoModoPreparo);

            return response.Models.Select(m => new ModoPreparoDto
            {
                IdPreparo = m.IdPreparo,
                DataCriacao = m.DataCriacao,
                QtdeEtapas = m.QtdeEtapas,
                InstrucoesPreparo = m.InstrucoesPreparo.Select(m => new Dominio.DTOs.ModoPreparoItem { Etapa = m.Etapa, Descricao = m.Descricao }).ToList(),
                Ingredientes = m.Ingredientes.Select(i => new Dominio.DTOs.IngredienteItem { Nome = i.Nome, Quantidade = i.Quantidade }).ToList(),
                Tempo = m.Tempo
            }).FirstOrDefault()!;
        }
    }
}
