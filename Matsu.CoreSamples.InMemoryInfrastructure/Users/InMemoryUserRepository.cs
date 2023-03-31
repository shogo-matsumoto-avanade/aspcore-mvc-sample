using Matsu.CoreSample.Common.Domain.Users;

namespace Matsu.CoreSamples.InMemoryInfrastructure.Users
{
    public class InMemoryUserRepository : IUserRepository
    {
        private Dictionary<string, User> _container = new Dictionary<string, User>();

        public InMemoryUserRepository()
        {
            _container.Clear();
            _container.Add("1", new User("1", "User 001"));
            _container.Add("2", new User("2", "User 001"));
            _container.Add("3", new User("3", "User 001"));
            _container.Add("4", new User("4", "User 001"));
        }

        public User Get(string id)
        {
            if (_container.ContainsKey(id))
            {
                return _container[id];
            }
            else
            {
                return new User("unknown", "Unknown User");
            }
        }
    }
}