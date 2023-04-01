using Matsu.CoreSample.Common.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Matsu.CoreSample.Common.Database.Data
{
    public class SqlServerCustomContext : DbContext
    {
        public SqlServerCustomContext(DbContextOptions<SqlServerCustomContext> options)
            : 
            base(options)
        {
        }

        public DbSet<KeyValue> KeyValue { get; set; } = default!;
    }
}
