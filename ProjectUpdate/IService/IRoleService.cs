using ProjectUpdateApp.Dto;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.IService
{
    public interface IRoleService
    {
        ICollection<Role> GetAllRoles();
        Role GetRolebyId(Guid id);

        bool RoleExists(Guid userId);

        bool CreateRole(Role role);
        bool UpdateRole(Guid id, RoleDto roledto);
        bool DeleteRole(Role role);
    }
}
