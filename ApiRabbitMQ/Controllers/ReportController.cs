using Microsoft.AspNetCore.Mvc;

namespace ApiRabbitMQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {


        [HttpGet("hello-world")]
        public IActionResult Get()
        {
            return Ok("Hello World");
        }

        [HttpPost("solicitar-relatorio/{name}")]
        public IActionResult SolicitarRelatorio(string name)
        {
            var solicitacao = new SolicitacaoRelatorio()
            {
                Id = Guid.NewGuid(),
                Nome = name,
                Status = "Pendente",
                ProcessedTime = null
            };

            Lista.Relatorios.Add(solicitacao);

            return Ok(solicitacao);
        }

        [HttpGet("relatorios")]
        public IActionResult Relatorios()
        {
            return Ok(Lista.Relatorios);
        }

    }
}
