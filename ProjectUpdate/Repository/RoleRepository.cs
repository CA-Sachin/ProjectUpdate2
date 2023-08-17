using ProjectUpdateApp.Data;
using ProjectUpdateApp.IRepository;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.Repository
{
    public class RoleRepository:IRoleRepository
    {
        private readonly DataContext _Context;

        public RoleRepository(DataContext Context)
        {
            _Context = Context;
        }

        public bool CreateRole(Role role)
        {
            _Context.Role.Add(role);
            return Save();
        }

        public bool DeleteRole(Role role)
        {
            _Context.Role.Remove(role);
            return Save();
        }

        public ICollection<Role> GetAllRoles()
        {
            return _Context.Role.ToList();
        }

        public Role GetRolebyId(Guid id)
        {
            return _Context.Role.Where(p => p.RoleId == id).FirstOrDefault();
        }

        public bool RoleExists(Guid Id)
        {
            return _Context.Role.Any(p => p.RoleId == Id);
        }

        public bool UpdateRole(Guid id, Role role)
        {
            _Context.Update(role);
            return Save();
        }
        public bool Save()
        {
            var saved = _Context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
