using ProjectUpdateApp.Dto;
using ProjectUpdateApp.IRepository;
using ProjectUpdateApp.IService;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.Service
{
    public class RoleService:IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public bool CreateRole(Role role)
        {
            var r = new Role
            {

                RoleName = role.RoleName,
                CreatedOn=DateTime.Now,
                IsDelete=false,
                CreatedBy="Admin"
            
              
            };
            return _roleRepository.CreateRole(r);
        }

        public bool DeleteRole(Role role)
        {
            return _roleRepository.DeleteRole(role);
        }

        public ICollection<Role> GetAllRoles()
        {
            return _roleRepository.GetAllRoles();
        }

        public Role GetRolebyId(Guid id)
        {
            return _roleRepository.GetRolebyId(id);
        }

        public bool RoleExists(Guid userId)
        {
            return _roleRepository.RoleExists(userId);
        }

        public bool UpdateRole(Guid id, RoleDto roleDto)
        {
            return _roleRepository.UpdateRole(id, roleDto);
        }
    }
}
