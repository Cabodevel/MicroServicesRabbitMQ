using MediatR;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace MicroRabbit.Infra.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddSingleton<IEventBus, RabbitMqBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                var optionsFactory = sp.GetService<IOptions<RabbitMqSettings>>();
                return new RabbitMqBus(sp.GetService<IMediator>(), scopeFactory, optionsFactory);
            });

            return services;
        }
    }
}
