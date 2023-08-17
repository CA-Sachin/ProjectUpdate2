using ProjectUpdateApp.Dto;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.IRepository
{
    public interface IRoleRepository
    {
        ICollection<Role> GetAllRoles();
        Role GetRolebyId(Guid id);

        bool RoleExists(Guid userId);

        bool CreateRole(Role roleDto);
        bool UpdateRole(Guid id, RoleDto roleDto);
        bool DeleteRole(Role role);
    }
}
