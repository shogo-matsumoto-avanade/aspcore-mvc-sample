namespace Matsu.CoreSample.Common.Domain.Users
{
    public class UserService : IUserService
    {
        readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Get(string userId)
        {
            return _userRepository.Get(userId);
        }
    }
}
