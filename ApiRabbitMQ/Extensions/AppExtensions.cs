using ApiRabbitMQ.Bus;
using MassTransit;

namespace ApiRabbitMQ.Extensions
{
    public static class AppExtensions
    {
        public static void AddRabbitMQServices(this IServiceCollection services)
        {
            services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.AddConsumer<RelatoriosSolicitadosEventConsumer>();

                busConfigurator.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(new Uri("amqp://localhost:5672"), host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });

                    cfg.ConfigureEndpoints(ctx);
                });
            });
        }
    }
}
