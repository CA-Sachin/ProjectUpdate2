using ProjectUpdateApp.Dto;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.IRepository
{
    public interface IUserRoleRepository
    {
        ICollection<UserRole> GetAllUserRole();
         ICollection< UserRoleDto> GetUserRolebyId(Guid id);
        
        public bool CreateUserRole(Guid userid, Guid roleid);
        public bool UpdateUserRole(Guid userid, Guid roleid);
        public bool DeleteUserRole(Guid id, Guid roleid);
    }
}
