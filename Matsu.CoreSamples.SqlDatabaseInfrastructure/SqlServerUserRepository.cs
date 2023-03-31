using Matsu.CoreSample.Common.Domain.Users;
using Matsu.CoreSamples.SqlDatabaseInfrastructure.Context;
using Matsu.CoreSamples.SqlDatabaseInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Matsu.CoreSamples.SqlDatabaseInfrastructure
{
    public class SqlServerUserRepository : IUserRepository
    {
        private readonly MyDatabaseContext _context;

        public SqlServerUserRepository(MyDatabaseContext context)
        {
            _context = context;
        }

        public User Get(string id)
        {
            return new User("Sample", "Sample");
            
        }
    }
}