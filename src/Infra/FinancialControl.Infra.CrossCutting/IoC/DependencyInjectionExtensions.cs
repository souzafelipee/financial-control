using FinancialControl.Application.Interfaces.UseCases;
using Microsoft.Extensions.DependencyInjection;
using FinancialControl.Application.UseCases.Transaction;
using FinancialControl.Domain.Interfaces.Repositories;
using FinancialControl.Infra.EntityFramework.Repository;

namespace FinancialControl.Infra.CrossCutting.IoC
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRegisterTransactionUseCase, TransactionUseCase>();

            services.AddScoped<ITransactionRepo, TransactionRepo>();

            return services;
        }
    }
}
