using Matsu.CoreSample.Common.Database.Data;
using Matsu.CoreSample.Common.Domain.Users;
using Matsu.CoreSamples.InMemoryInfrastructure.Data;
using Matsu.CoreSamples.InMemoryInfrastructure.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace Matsu.CoreSample.Web.Settings
{
    public static class ServiceProviderCustomExtensions
    {
        public static void ConfigureCustomContext(this IServiceProvider provider, DependencyInjectionTypes diType)
        {
            if (diType.IsProduction())
            {
                // No additional configuration
            }
            else
            {
                InitializeInMemoryDatabase(provider);
            }
        }


        private static void InitializeInMemoryDatabase(IServiceProvider provider)
        {
            var scope = provider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SqlServerCustomContext>();
            context.InitializeData();
        }
    }
}
