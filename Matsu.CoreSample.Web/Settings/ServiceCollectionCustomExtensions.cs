using Matsu.CoreSample.Common.Database.Data;
using Matsu.CoreSample.Common.Domain.Users;
using Matsu.CoreSamples.InMemoryInfrastructure.Users;
using Microsoft.EntityFrameworkCore;

namespace Matsu.CoreSample.Web.Settings
{
    public static class ServiceCollectionCustomExtensions
    {
        public static void InjectCustomDependency(this IServiceCollection collection, string injectionType)
        {
            var dependency = CreateInjectionType(injectionType);

            switch (dependency)
            {
                case DependencyInjectionTypes.Stub:
                    InitializeStub(collection);
                    break;
                case DependencyInjectionTypes.Production:
                    Initialize(collection);
                    break;
                default:
                    InitializeStub(collection);
                    break;
            }
        }

        public static void InjectDatabaseDependency(this IServiceCollection collection, string injectionType, string connectionString)
        {
            var dependency = CreateInjectionType(injectionType);

            switch (dependency)
            {
                case DependencyInjectionTypes.Stub:
                    InitializeDatabaseStub(collection);
                    break;
                case DependencyInjectionTypes.Production:
                    InitializeDatabase(collection, connectionString);
                    break;
                default:
                    InitializeDatabaseStub(collection);
                    break;

            }

        }


        private static DependencyInjectionTypes CreateInjectionType(string injectionType)
        {
            DependencyInjectionTypes dependency;
            if (injectionType == null || !Enum.TryParse(injectionType, out dependency))
            {
                dependency = DependencyInjectionTypes.Production;
            }
            else
            {
                dependency = Enum.Parse<DependencyInjectionTypes>(injectionType);
            }
            return dependency;
        }

        #region Injection Service Repository

        private static void Initialize(IServiceCollection collection)
        {
            collection.AddSingleton<IUserRepository, InMemoryUserRepository>();
            collection.AddTransient<IUserService, UserService>();
        }

        private static void InitializeStub(IServiceCollection collection)
        {
            collection.AddSingleton<IUserRepository, InMemoryUserRepository>();
            collection.AddTransient<IUserService, UserService>();
        }
        #endregion

        #region Injection Database

        private static void InitializeDatabase(IServiceCollection collection, string connectionString)
        {
            collection.AddDbContext<SqlServerCustomContext>(options => options.UseSqlServer(connectionString));
        }
        private static void InitializeDatabaseStub(IServiceCollection collection)
        {
            //collection.AddDbContext<InMemoryCustomDatabaseContext>(options => options.UseInMemoryDatabase("DBMemory"));
        }
        #endregion
    }
}
