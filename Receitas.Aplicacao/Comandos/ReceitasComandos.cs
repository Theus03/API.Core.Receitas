using Microsoft.Extensions.Configuration;
using Receitas.Dominio.DTOs;
using Receitas.Dominio.Entidades;
using Receitas.Dominio.Requests;
using Receitas.Repositorio.Comandos;
using Receitas.Repositorio.Consultas;

namespace Receitas.Aplicacao.Comandos
{
    public class ReceitasComandos : IReceitasComandos
    {
        private readonly IReceitasComandosRepositorio _comandos;
        private readonly IReceitasConsultaRepositorio _consultas;
        private readonly IConfiguration _configuration;

        public ReceitasComandos(IReceitasComandosRepositorio comandos, IReceitasConsultaRepositorio consultas, IConfiguration configuration)
        {
            _comandos = comandos;
            _consultas = consultas;
            _configuration = configuration;
        }

        public async Task<ReceitaDto> InserirReceita(InserirReceitaRequest receitaRequest)
        {

            string imagemUrl = _configuration["NoImageBucket"]!;

            if (receitaRequest.Imagem != null)
            {
                imagemUrl = _comandos.InserirImagemReceita(receitaRequest);
            }

            var tiposReceitasExistentes = _consultas.ObterTiposReceitas().Result;

            if (tiposReceitasExistentes.Any(tr => tr.IdTipoReceita != receitaRequest.IdTipoReceita))
            {
                await InserirTipoReceita(new TiposReceitaDto
                {
                    IdTipoReceita = receitaRequest.IdTipoReceita,
                    DataCriacao = DateTime.Now,
                    TipoReceita  = receitaRequest.TipoReceita,
                    QuantidadeReceitas = 1 
                });
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
