using ProjectUpdateApp.Dto;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.IRepository
{
    public interface IUserRepository
    {
        bool CreateUser(User user);
        bool UpdateUser(Guid id, User user);

        public ICollection<User> GetRegistration();
        public UserDto GetDetils (string Email);
        User GetUserbyId(Guid id);

        bool UserExists(Guid userId);
        bool DeleteUser(User user);
    }
}
