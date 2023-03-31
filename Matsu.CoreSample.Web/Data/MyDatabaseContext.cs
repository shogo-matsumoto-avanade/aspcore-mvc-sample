using Matsu.CoreSample.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Matsu.CoreSample.Web.Data
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
