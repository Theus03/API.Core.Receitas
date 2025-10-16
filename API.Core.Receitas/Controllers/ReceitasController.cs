using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Receitas.Dominio.Entidades;
using Receitas.Aplicacao.Consultas;
using Receitas.Dominio.DTOs;
using Receitas.Aplicacao.Comandos;

namespace API.Core.Receitas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReceitasController : ControllerBase
    {
        private readonly IReceitasConsultas _consultas;
        private readonly IReceitasComandos _comandos;

        public ReceitasController(IReceitasConsultas consultas, IReceitasComandos comandos)
        {
            _consultas = consultas;
            _comandos = comandos;
        }

        [HttpGet("ListarReceitas")]
        [SwaggerOperation(Summary = "Método para listar e pesquisar as receitas")]
        [ProducesResponseType(typeof(IEnumerable<ReceitaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListarReceitas()
        {
            try
            {
                var resultado = await Task.Run(() => _consultas.ObterListaReceitas());
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        [HttpPost("InserirReceita")]
        [SwaggerOperation(Summary = "Método para inserir uma receita")]
        [ProducesResponseType(typeof(ReceitaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> InserirReceita([FromBody] ReceitaDto receita)
        {
            try
            {
                var resultado = await Task.Run(() => _comandos.InserirReceita(receita));
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }
    }
}
