using ProjectUpdateApp.Dto;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.IService
{
    public interface IUserRoleService
    {
        ICollection<UserRole> GetAllUserRole();
        UserRoleDto GetUserRolebyId(Guid id);
      
        public bool CreateUserRole(Guid  userid, Guid roleid);
        public bool UpdateUserRole(Guid userid, Guid roleid);
        public bool DeleteUserRole(Guid id, Guid roleid);

    }
}
