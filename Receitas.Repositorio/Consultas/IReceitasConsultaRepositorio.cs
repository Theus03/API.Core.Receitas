using Receitas.Dominio.DTOs;
using Receitas.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Repositorio.Consultas
{
    public interface IReceitasConsultaRepositorio
    {
        public Task<IEnumerable<ReceitaDto>> ObterReceitas();
        public Task<IEnumerable<TiposReceitaDto>> ObterTiposReceitas();
    }
}
