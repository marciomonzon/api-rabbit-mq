using MassTransit;

namespace ApiRabbitMQ.Bus
{
    public class RelatoriosSolicitadosEventConsumer : IConsumer<RelatorioSolicitadoEvent>
    {
        private readonly ILogger<RelatoriosSolicitadosEventConsumer> _logger;

        public RelatoriosSolicitadosEventConsumer(ILogger<RelatoriosSolicitadosEventConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<RelatorioSolicitadoEvent> context)
        {
            var message = context.Message;

            _logger
            .LogInformation("Processando Relatório id: {id}, Nome: {Nome}", message.id, message.Name);

            await Task.Delay(5000);

            var relatorio = Lista.Relatorios.FirstOrDefault(x => x.Id == message.id);

            if (relatorio != null) 
            {
                relatorio.Status = "Completo";
                relatorio.ProcessedTime = DateTime.UtcNow;
            }

            _logger
            .LogInformation("Relatório Processado id: {id}, Nome: {Nome}", message.id, message.Name);
        }
    }
}
