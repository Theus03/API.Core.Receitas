using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Receitas.Dominio.Entidades;
using Receitas.Aplicacao.Consultas;
using Receitas.Dominio.DTOs;

namespace API.Core.Receitas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReceitasController : ControllerBase
    {
        private readonly IReceitasConsultas _consultas;

        public ReceitasController(IReceitasConsultas consultas)
        {
            _consultas = consultas;
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
    }
}
