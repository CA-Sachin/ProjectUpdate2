using ProjectUpdateApp.Dto;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.IService
{
    public class IUserRoleService
    {
        ICollection<UserRoleDto> GetAllUserRole();
        UserRoleDto GetUserRolebyId(Guid id);
        bool UserRoleExist(Guid id);
        public bool CreateUserRole(User user, Role role);
        public bool UpdateUserRole(Guid id, UserRoleDto userroleDto);
        public bool DeleteUserRole(Guid id);
    }
}
