using Microsoft.AspNetCore.Mvc;
using Receitas.Aplicacao.Comandos;
using Receitas.Dominio.DTOs;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Core.Receitas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModoPreparoController : ControllerBase
    {
        private readonly IModoPreparoComando _comandos;

        public ModoPreparoController(IModoPreparoComando comandos)
        {
            _comandos = comandos;
        }

        [HttpPost]
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
