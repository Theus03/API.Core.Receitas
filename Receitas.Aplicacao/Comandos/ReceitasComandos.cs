using Receitas.Dominio.DTOs;
using Receitas.Dominio.Entidades;
using Receitas.Repositorio.Comandos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Aplicacao.Comandos
{
    public class ReceitasComandos : IReceitasComandos
    {
        private readonly IReceitasComandosRepositorio _comandos;

        public ReceitasComandos(IReceitasComandosRepositorio comandos)
        {
            _comandos = comandos;
        }

        public async Task<ReceitaDto> InserirReceita(ReceitaDto receita)
        {
            return await _comandos.InserirReceita(receita);
        }

        public async Task<TiposReceitaDto> InserirTipoReceita(TiposReceitaDto tipoReceita)
        {
            return await _comandos.InserirTipoReceita(tipoReceita);
        }
    }
}
