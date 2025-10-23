using Receitas.Dominio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Repositorio.Consultas
{
    public interface IModoPreparoConsultaRepositorio
    {
        public Task<ModoPreparoDto> ObterModoPreparoPorIdReceita(int idReceita);
    }
}
