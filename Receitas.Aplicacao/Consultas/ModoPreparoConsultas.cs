using Receitas.Dominio.DTOs;
using Receitas.Repositorio.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Aplicacao.Consultas
{
    public class ModoPreparoConsultas : IModoPreparoConsultas
    {
        private readonly IModoPreparoConsultaRepositorio _consultas;

        public ModoPreparoConsultas(IModoPreparoConsultaRepositorio consultas)
        {
            _consultas = consultas;
        }

        public async Task<ModoPreparoDto> ObterModoPreparoPorIdReceita(int idReceita)
        {
            return await _consultas.ObterModoPreparoPorIdReceita(idReceita);
        }
    }
}
