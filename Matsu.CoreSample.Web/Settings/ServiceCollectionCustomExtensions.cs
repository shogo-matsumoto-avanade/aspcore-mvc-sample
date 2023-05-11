using Matsu.CoreSample.Common.Database.Data;
using Matsu.CoreSample.Common.Domain.Users;
using Matsu.CoreSamples.InMemoryInfrastructure.Users;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace Matsu.CoreSample.Web.Settings
{
    public static class ServiceCollectionCustomExtensions
    {
        #region Service Repository Dependency Injection

        public static void InjectServiceRepositoryDependency(this IServiceCollection services, DependencyInjectionTypes diType)
        {
            if (diType.IsProduction())
            {
                Initialize(services);
            }
            else
            {
                InitializeStub(services);
            }
        }

        private static void Initialize(IServiceCollection collection)
        {
            collection.AddSingleton<IUserRepository, InMemoryUserRepository>();
            collection.AddTransient<IUserService, UserService>();
        }

        private static void InitializeStub(IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, InMemoryUserRepository>();
            services.AddTransient<IUserService, UserService>();
        }
        #endregion

        #region Logger Injection

        public static void InjectLoggerDependency(this IServiceCollection services, OperationEnvironments env)
        {
            if (env.IsAzure())
            {
                services.AddApplicationInsightsTelemetry();
            }
            else
            {
                // No additional configuration
            }
        }

        #endregion

        #region Entity Framework Database Injection 

        public static void InjectDatabaseDependency(this IServiceCollection services, DependencyInjectionTypes diType, string connectionString)
        {
            if (diType.IsProduction())
            {
                InitializeDatabase(services, connectionString);
            }
            else
            {
                InitializeDatabaseStub(services);
            }
        }

        private static void InitializeDatabase(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SqlServerCustomContext>(options => options.UseSqlServer(connectionString));
        }
        private static void InitializeDatabaseStub(IServiceCollection services)
        {
            services.AddDbContext<SqlServerCustomContext>(options => options.UseInMemoryDatabase("InMemoryDB"));
        }
        #endregion
    }
}
