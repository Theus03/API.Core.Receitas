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
    }
}
