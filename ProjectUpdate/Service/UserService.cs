using ProjectUpdateApp.Dto;
using ProjectUpdateApp.IRepository;
using ProjectUpdateApp.IService;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.Service
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }
        public bool CreateUser(User user)
        {
            var u = new User
            {
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
             
                CreatedDate = DateTime.UtcNow,

                IsActive = true,
                IsDelete = false

            };
            return _userRepository.CreateUser(u);
        }

        public bool DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public UserDto GetDetils(string Email)
        {
           return _userRepository.GetDetils(Email);
        }

        public ICollection<User> GetRegistration()
        {
            return _userRepository.GetRegistration();
        }

        public User GetUserbyId(Guid id)
        {
            return _userRepository.GetUserbyId(id);
        }

        public bool UpdateUser(Guid id, User user)
        {
            return _userRepository.UpdateUser(id, user);
        }

        public bool UserExists(Guid userId)
        {
            return _userRepository.UserExists(userId);
        }

    }
}
