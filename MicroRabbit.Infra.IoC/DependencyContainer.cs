using MicroRabbit.Api.Application.Interfaces;
using MicroRabbit.Api.Application.Services;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroRabbit.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEventBus, RabbitMqBus>();

            services.Configure<RabbitMqSettings>(c => configuration.GetSection("RabbitMqSettings"));

            //Application
            services.AddScoped<IAccountService, AccountService>();

            //Data
            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddScoped<BankingDbContext>();
        }
    }
}
