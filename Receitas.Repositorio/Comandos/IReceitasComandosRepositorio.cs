using Receitas.Dominio.DTOs;
using Receitas.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Repositorio.Comandos
{
    public interface IReceitasComandosRepositorio
    {
        public Task<ReceitaDto> InserirReceita(ReceitaDto receita);
        public Task<TiposReceitaDto> InserirTipoReceita(TiposReceitaDto tipoReceita);
    }
}
