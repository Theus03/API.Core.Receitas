using Receitas.Dominio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Repositorio.Comandos
{
    public interface IModoPreparoComandosRepositorio
    {
        public Task<ModoPreparoDto> InserirModoPreparo(ModoPreparoDto modoPreparo);
    }
}
