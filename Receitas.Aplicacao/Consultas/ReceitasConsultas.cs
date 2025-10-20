using Receitas.Dominio.DTOs;
using Receitas.Dominio.Entidades;
using Receitas.Repositorio.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Aplicacao.Consultas
{
    public class ReceitasConsultas : IReceitasConsultas
    {
        private readonly IReceitasConsultaRepositorio _consultas;

        public ReceitasConsultas(IReceitasConsultaRepositorio consultas )
        {
            _consultas = consultas;
        }

        public async Task<IEnumerable<ReceitaDto>> ObterListaReceitas()
        {
            IEnumerable<ReceitaDto> receitas = await _consultas.ObterReceitas();
            return receitas;
        }

        public async Task<ReceitaDto> ObterReceitaPorId(int id)
        {
            ReceitaDto receita = await _consultas.ObterReceitaPorId(id);
            return receita;
        }

        public async Task<IEnumerable<TiposReceitaDto>> ObterListaTiposReceita()
        {
            IEnumerable<TiposReceitaDto> tiposReceitas = await _consultas.ObterTiposReceitas();
            return tiposReceitas;
        }
    }
}
