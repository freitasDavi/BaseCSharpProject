using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Clientes;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Repositories.Incomes;
using CashFlow.Domain.Repositories.Orcamentos;
using CashFlow.Domain.Repositories.Pecas;
using CashFlow.Domain.Security;
using CashFlow.Infrastructure.DataAccess;
using CashFlow.Infrastructure.DataAccess.Repositories;
using CashFlow.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);
            AddRepositories(services);
            AddToken(services, configuration);
            services.AddScoped<IPasswordEncripter, Cryptography>();
        }

        private static void AddToken(this IServiceCollection services, IConfiguration configuration)
        {
            var expirationTimeInMinutes = configuration.GetValue<uint>("Jwt:ExpiresMinutes");
            var signingkey = configuration.GetValue<string>("Jwt:SigningKey");

            services.AddScoped<IAccessTokenGenerator>(config => new JwtTokenGenerator(expirationTimeInMinutes, signingkey!));

        }

        private static void AddRepositories (IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnityOfWork>();
            services.AddScoped<IExpensesWriteOnlyRepository, ExpensesRepository>();
            services.AddScoped<IExpensesReadOnlyRepository, ExpensesRepository>();
            services.AddScoped<IExpensesUpdateOnlyRepository, ExpensesRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IIncomesRepository, IncomesRepository>();



            services.AddScoped<IPecasRepository, PecasRepository>();  
            services.AddScoped<IOrcamentosRepository, OrcamentosRepository>();  
            services.AddScoped<IItensOrcamentoRepository, ItensOrcamentoRepository>();  
            services.AddScoped<IClientesRepository, ClientesRepository>();
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = configuration.GetConnectionString("Connection");

            services.AddDbContext<CashFlowDbContext>(options => options.UseNpgsql(connectionString));
        }
    }
}
