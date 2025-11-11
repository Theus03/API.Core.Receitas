using Microsoft.Extensions.Configuration;
using Receitas.Dominio.DTOs;
using Receitas.Dominio.Entidades;
using Receitas.Dominio.Filtros;
using Receitas.Repositorio.Conexao;
using Supabase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Repositorio.Consultas
{
    public class ReceitasConsultaRepositorio : IReceitasConsultaRepositorio
    {
        private readonly IConfiguration _configuration;
        private readonly IModoPreparoConsultaRepositorio _modoPreparoConsulta;
        private readonly IContextDB _contextDB;

        public ReceitasConsultaRepositorio(IConfiguration configuration, IModoPreparoConsultaRepositorio modoPreparoConsulta, IContextDB contextDB)
        {
            _configuration = configuration;
            _modoPreparoConsulta = modoPreparoConsulta;
            _contextDB = contextDB;
        }

        public async Task<IEnumerable<ReceitaDto>> ObterReceitas(FiltroListarReceitas filtro)
        {
            var client = await _contextDB.ObterConexao();

            var resposta = await client.From<Receita>().Get();

            var receitas = resposta.Models.AsQueryable();

            if (!string.IsNullOrEmpty(filtro.Nome))
                receitas = receitas.Where(r => r.Nome!.ToUpper().Contains(filtro.Nome!.ToUpper().Trim()));

            if (!string.IsNullOrEmpty(filtro.TipoReceita))
            {
                var tiposReceita = await ObterTiposReceitas();
                tiposReceita = tiposReceita.Where(t => t.TipoReceita!.ToUpper() == filtro.TipoReceita!.ToUpper().Trim());
                receitas = receitas.Where(r => r.IdTipoReceita == tiposReceita.First().IdTipoReceita);
            }

            if (!string.IsNullOrEmpty(filtro.Tempo))
            {
                var modoPreparo = await _modoPreparoConsulta.ObterListarModoPreparo();
                TimeSpan tempoMaximo = TimeSpan.Parse(filtro.Tempo);

                var idsValidos = modoPreparo.Where(m => m.Tempo.HasValue && m.Tempo.Value <= tempoMaximo).Select(m => m.IdReceita).Distinct().ToList();
                receitas = receitas.Where(r => idsValidos.Contains(r.IdReceita));
            }


            return receitas.Select(r => new ReceitaDto
            {
                IdReceita = r.IdReceita,
                IdTipoReceita = r.IdTipoReceita,
                DataCriacao = r.DataCriacao,
                Nome = r.Nome,
                Imagem = r.Imagem
            });
        }

        public async Task<ReceitaDto> ObterReceitaPorId(int id)
        {
           var client = await _contextDB.ObterConexao();

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
            var client = await _contextDB.ObterConexao();

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
