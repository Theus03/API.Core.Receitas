using Microsoft.Extensions.Configuration;
using Receitas.Dominio.DTOs;
using Receitas.Dominio.Entidades;
using Receitas.Dominio.Requests;
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
        private readonly IConfiguration _configuration;

        public ReceitasComandos(IReceitasComandosRepositorio comandos, IConfiguration configuration) {
            _comandos = comandos;
            _configuration = configuration;
        } 

        public async Task<ReceitaDto> InserirReceita(InserirReceitaRequest receitaRequest) {

            string imagemUrl = _configuration["NoImageBucket"]!;

            if (receitaRequest.Imagem != null) {
                imagemUrl = _comandos.InserirImagemReceita(receitaRequest);
            }

            Receita receita = new Receita
            {
                IdTipoReceita = receitaRequest.IdTipoReceita,
                Imagem = imagemUrl,
            };

            return await _comandos.InserirReceita(receita);
        }

        public async Task<TiposReceitaDto> InserirTipoReceita(TiposReceitaDto tipoReceita) => await _comandos.InserirTipoReceita(tipoReceita);
    }
}
