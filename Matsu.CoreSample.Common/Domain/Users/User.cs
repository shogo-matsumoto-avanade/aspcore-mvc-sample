using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matsu.CoreSample.Common.Domain.Users
{
    public class User
    {
        public User(string id, string name)
        {
            if (id == null) throw new ArgumentNullException("id");
            if (name == null) throw new ArgumentNullException("name");

            this.Id = id;
            this.Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
