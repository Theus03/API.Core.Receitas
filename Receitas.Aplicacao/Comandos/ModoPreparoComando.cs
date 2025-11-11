using Receitas.Dominio.DTOs;
using Receitas.Repositorio.Comandos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Aplicacao.Comandos
{
    public class ModoPreparoComando : IModoPreparoComando
    {

        private readonly IModoPreparoComandosRepositorio _comandos;

        public ModoPreparoComando(IModoPreparoComandosRepositorio comandos) =>  _comandos = comandos;

        public Task<ModoPreparoDto> InserirModoPreparo(ModoPreparoDto modoPreparo) => _comandos.InserirModoPreparo(modoPreparo);  
    }
}
