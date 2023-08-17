using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.IService
{
    public interface IRoleService
    {
        ICollection<Role> GetAllRoles();
        Role GetRolebyId(Guid id);

        bool RoleExists(Guid userId);

        bool CreateRole(Role roleDto);
        bool UpdateRole(Guid id, Role roleDto);
        bool DeleteRole(Role role);
    }
}
