namespace Matsu.CoreSample.Common.Domain.Users
{
    public interface IUserRepository
    {
        public User Get(string id);
    }
}
