using Microsoft.EntityFrameworkCore;
using Matsu.CoreSamples.SqlDatabaseInfrastructure.Data;

namespace Matsu.CoreSamples.SqlDatabaseInfrastructure.Context
{
    public class MyDatabaseContext : DbContext
    {
        public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<KeyValue> KeyValue { get; set; } = default!;
    }
}
