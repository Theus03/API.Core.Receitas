using Receitas.Dominio.DTOs;
using Receitas.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Aplicacao.Comandos
{
    public interface IReceitasComandos
    {
        public Task<ReceitaDto> InserirReceita(ReceitaDto receita);
    }
}
