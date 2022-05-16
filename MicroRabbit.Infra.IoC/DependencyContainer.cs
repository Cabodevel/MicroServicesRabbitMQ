using MediatR;
using MicroRabbit.Api.Application.Interfaces;
using MicroRabbit.Api.Application.Services;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Domain.CommandHandlers;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Application.Services;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Data.Repository;
using MicroRabbit.Transfer.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroRabbit.Infra.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            services.AddScoped<IEventBus, RabbitMqBus>();

            //Application
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITransferService, TransferService>();

            //Data
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ITransferRepository, TransferRepository>();

            services.AddScoped<BankingDbContext>();
            services.AddScoped<TransferDbContext>();

            return services;
        }
    }
}
