using Matsu.CoreSample.Common.Database.Data;
using Matsu.CoreSample.Common.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Matsu.CoreSamples.InMemoryInfrastructure.Data
{
    public class InMemoryCustomDatabaseContext : SqlServerCustomContext
    {
        public InMemoryCustomDatabaseContext(DbContextOptions<SqlServerCustomContext> options) : base(options)
        {
            InitializeData();
        }

        private void InitializeData()
        {
            KeyValue.Add(new KeyValue() { id = 1, name = "Stub 001", value = "Stub Data 001" });
            KeyValue.Add(new KeyValue() { id = 2, name = "Stub 002", value = "Stub Data 002" });
            KeyValue.Add(new KeyValue() { id = 3, name = "Stub 003", value = "Stub Data 003" });
            KeyValue.Add(new KeyValue() { id = 4, name = "Stub 004", value = "Stub Data 004" });
        }
    }
}
