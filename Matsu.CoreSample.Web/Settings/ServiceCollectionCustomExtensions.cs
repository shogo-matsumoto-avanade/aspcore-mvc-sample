using Matsu.CoreSample.Common.Domain.Users;
using Matsu.CoreSamples.InMemoryInfrastructure.Users;

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
    }
}
