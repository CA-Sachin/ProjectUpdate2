using ProjectUpdateApp.Dto;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.IService
{
    public interface IUserService
    {

        bool CreateUser(User user);
        bool UpdateUser(Guid id, User user);
        ICollection<User> GetRegistration();
        public UserDto GetDetils(string Email);
        User GetUserbyId(Guid id);
        bool UserExists(Guid userId);
        bool DeleteUser(User register);
    }
}
