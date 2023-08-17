using ProjectUpdateApp.Dto;
using ProjectUpdateApp.IRepository;
using ProjectUpdateApp.IService;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.Service
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleService(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }
        public bool CreateUserRole(Guid userid, Guid roleid)
        {
            return _userRoleRepository.CreateUserRole(userid, roleid);
        }

        public bool DeleteUserRole(Guid id,Guid roleid)
        {
            return _userRoleRepository.DeleteUserRole(id, roleid);
        }

        public ICollection<UserRole> GetAllUserRole()
        {
          return _userRoleRepository.GetAllUserRole();
        }

        public UserRoleDto GetUserRolebyId(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUserRole(Guid id, Guid Roleid)
        {
           return _userRoleRepository.UpdateUserRole(id, Roleid);
        }

        public bool UserRoleExist(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
