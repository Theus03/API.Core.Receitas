using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Receitas.Dominio.Entidades;
using Receitas.Aplicacao.Consultas;
using Receitas.Dominio.DTOs;
using Receitas.Aplicacao.Comandos;
using Receitas.Dominio.Filtros;
using Receitas.Dominio.Requests;

namespace API.Core.Receitas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReceitasController : ControllerBase
    {
        private readonly IReceitasConsultas _consultas;
        private readonly IReceitasComandos _comandos;
        private readonly ILogger<ReceitasController> _logger;

        public ReceitasController(IReceitasConsultas consultas, IReceitasComandos comandos, ILogger<ReceitasController> logger)
        {
            _consultas = consultas;
            _comandos = comandos;
            _logger = logger;
        }

        [HttpPost("ListarReceitas")]
        [SwaggerOperation(Summary = "Método para listar e pesquisar as receitas")]
        [ProducesResponseType(typeof(IEnumerable<ReceitaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListarReceitas([FromBody] FiltroListarReceitas filtro)
        {
            try
            {
                _logger.LogInformation("Iniciando a listagem de receitas.");

                var resultado = await Task.Run(() => _consultas.ObterListaReceitas(filtro));
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        [HttpGet("ObterReceita")]
        [SwaggerOperation(Summary = "Método para obter uma receita pelo Id")]
        [ProducesResponseType(typeof(ReceitaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ObterReceita([FromQuery] int idReceita)
        {
            try
            {
                _logger.LogInformation($"Obtendo a receita com Id: {idReceita}");
                var receita = await Task.Run(() => _consultas.ObterReceitaPorId(idReceita));
                if (receita == null)
                {
                    return NotFound(new { Mensagem = "Receita não encontrada." });
                }
                return Ok(receita);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        [HttpPost("InserirReceita")]
        [Consumes("multipart/form-data")]
        [SwaggerOperation(Summary = "Método para inserir uma receita")]
        [ProducesResponseType(typeof(ReceitaDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> InserirReceita([FromForm] InserirReceitaRequest receita)
        {
            try
            {
                _logger.LogInformation("Inserindo uma nova receita.");
                var resultado = await _comandos.InserirReceita(receita);
                return Ok(resultado);
            }   
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        [HttpGet("ListarTiposReceitas")]
        [SwaggerOperation(Summary = "Método para listar os tipos da receita")]
        [ProducesResponseType(typeof(IEnumerable<TiposReceitaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListarTiposReceitas()
        {
            try
            {
                _logger.LogInformation("Iniciando a listagem de tipos de receitas.");
                var resultado = await Task.Run(() => _consultas.ObterListaTiposReceita());
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        [HttpPost("InserirTiposReceitas")]
        [SwaggerOperation(Summary = "Método para inserir o tipo da receita")]
        [ProducesResponseType(typeof(TiposReceitaDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> InserirTiposReceitas([FromBody] TiposReceitaDto tipoReceita)
        {
            try
            {
                _logger.LogInformation("Inserindo um novo tipo de receita.");
                var resultado = await Task.Run(() => _comandos.InserirTipoReceita(tipoReceita));
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }
    }
}
