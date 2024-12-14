using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace ApiRabbitMQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IBus _bus;

        public ReportController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost("solicitar-relatorio/{name}")]
        public async Task<IActionResult> SolicitarRelatorioAsync(string name)
        {
            var solicitacao = new SolicitacaoRelatorio()
            {
                Id = Guid.NewGuid(),
                Nome = name,
                Status = "Pendente",
                ProcessedTime = null
            };

            Lista.Relatorios.Add(solicitacao);

            var evento = new RelatorioSolicitadoEvent(solicitacao.Id, solicitacao.Nome);

            await _bus.Publish(evento);

            return Ok(solicitacao);
        }

        [HttpGet("relatorios")]
        public IActionResult Relatorios()
        {
            return Ok(Lista.Relatorios);
        }

    }
}
