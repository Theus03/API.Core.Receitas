using Receitas.Dominio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Aplicacao.Comandos
{
    public interface IModoPreparoComando
    {
        public Task<ModoPreparoDto> InserirModoPreparo(ModoPreparoDto modoPreparo);
    }
}
