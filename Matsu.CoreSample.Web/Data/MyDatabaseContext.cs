using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Matsu.CoreSample.Web.Models;

namespace Matsu.CoreSample.Web.Data
{
    public class MyDatabaseContext : DbContext
    {
        public MyDatabaseContext (DbContextOptions<MyDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Matsu.CoreSample.Web.Models.KeyValue> KeyValue { get; set; } = default!;
    }
}
