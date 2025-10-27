using Receitas.Dominio.DTOs;
using Receitas.Dominio.Entidades;
using Receitas.Dominio.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Aplicacao.Consultas
{
    public interface IReceitasConsultas
    {
        public Task<IEnumerable<ReceitaDto>> ObterListaReceitas(FiltroListarReceitas filtro);
        public Task<ReceitaDto> ObterReceitaPorId(int id);
        public Task<IEnumerable<TiposReceitaDto>> ObterListaTiposReceita();
    }
}
