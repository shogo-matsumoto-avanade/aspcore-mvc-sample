using Matsu.CoreSample.Common.Database.Data;
using Matsu.CoreSample.Common.Database.Models;

namespace Matsu.CoreSamples.InMemoryInfrastructure.Data
{
    public static class InMemorySqlServerCustomContextExtensions
    {
        public static void InitializeData(this SqlServerCustomContext context)
        {
            context.KeyValue.Add(new KeyValue { id = 1, name = "Stub 001", value = "Stub Data 001" });
            context.KeyValue.Add(new KeyValue { id = 2, name = "Stub 002", value = "Stub Data 002" });
            context.KeyValue.Add(new KeyValue { id = 3, name = "Stub 003", value = "Stub Data 003" });
            context.KeyValue.Add(new KeyValue { id = 4, name = "Stub 004", value = "Stub Data 004" });
            context.SaveChanges();
        }
     }
}
