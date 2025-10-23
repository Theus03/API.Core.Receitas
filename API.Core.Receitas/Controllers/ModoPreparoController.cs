using Microsoft.AspNetCore.Mvc;
using Receitas.Aplicacao.Comandos;
using Receitas.Aplicacao.Consultas;
using Receitas.Dominio.DTOs;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Core.Receitas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModoPreparoController : ControllerBase
    {
        private readonly IModoPreparoComando _comandos;
        private readonly IModoPreparoConsultas _consultas; 

        public ModoPreparoController(IModoPreparoComando comandos, IModoPreparoConsultas consultas)
        {
            _comandos = comandos;
            _consultas = consultas;
        }

        [HttpGet("ObterModoPreparo")]
        [SwaggerOperation(Summary = "Método para obter o modo de preparo de uma receita")]
        [ProducesResponseType(typeof(IEnumerable<ModoPreparoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListarModoPreparo([FromQuery] int idReceita)
        {
            try
            {
                var resultado = await Task.Run(() => _consultas.ObterModoPreparoPorIdReceita(idReceita));
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        [HttpPost("InserirModoPreparo")]
        [SwaggerOperation(Summary = "Método para inserir um modo de preparo")]
        [ProducesResponseType(typeof(ModoPreparoDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> InserirModoPreparo([FromBody] ModoPreparoDto modoPreparo)
        {
            try
            {
                var resultado = await Task.Run(() => _comandos.InserirModoPreparo(modoPreparo));
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message }); 
            }
        }
    }
}
