using Receitas.Dominio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Aplicacao.Consultas
{
    public interface IModoPreparoConsultas
    {
        public Task<ModoPreparoDto> ObterModoPreparoPorIdReceita(int idReceita);
    }
}
