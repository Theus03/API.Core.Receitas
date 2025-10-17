using Receitas.Dominio.DTOs;
using Receitas.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Aplicacao.Consultas
{
    public interface IReceitasConsultas
    {
        public Task<IEnumerable<ReceitaDto>> ObterListaReceitas();
        public Task<IEnumerable<TiposReceitaDto>> ObterListaTiposReceita();
    }
}
