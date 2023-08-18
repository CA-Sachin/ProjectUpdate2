using Microsoft.EntityFrameworkCore;
using ProjectUpdateApp.Data;
using ProjectUpdateApp.Dto;
using ProjectUpdateApp.IRepository;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.Repository
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly DataContext _Context;

        public UserRoleRepository(DataContext Context)
        {

            _Context = Context;
        }
        public bool CreateUserRole(Guid userid, Guid roleid)
        {
            var user = _Context.User.Find(userid);
            var role = _Context.Role.Find(roleid);

             var uid=_Context.UserRole.Where(x=>x.Userid == userid).FirstOrDefault();
             var rid=_Context.UserRole.Where(x=>x.Roleid == roleid).FirstOrDefault();
            if (uid != null && rid != null)
                return false;
            if (user == null || role == null)
            {
                return false; 
            }

         
            var userRoleMapping = new UserRole
            {
               Userid = userid,
               Roleid = roleid,
               IsDelete = false,
               CreatedOn = DateTime.UtcNow,
               CreatedBy="Admin"
               
            };

            _Context.UserRole.Add(userRoleMapping);
            return Save();

        }

        public bool DeleteUserRole(Guid userid,Guid roleid)
        {
            var uid=_Context.UserRole.Where(x=>x.Userid==userid).FirstOrDefault();
            var rid=_Context.UserRole.Where(x=>x.Roleid==roleid).FirstOrDefault();

            

            if(uid == null || rid == null)
                return false;

            _Context.UserRole.Remove(uid);
            _Context.UserRole.Remove(rid);
            return Save();

        }

        public ICollection<UserRole> GetAllUserRole()
        {
            return _Context.UserRole.ToList();
        }

        public UserRoleDto GetUserRolebyId(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUserRole(Guid userid, Guid roleid)
        {   
            var ur=_Context.UserRole.Where(x=>x.Userid==userid).FirstOrDefault();

         
            var role = _Context.Role.Where(x =>x.RoleId ==roleid).FirstOrDefault();
            if (role == null) { return false; }
            
            ur.Roleid = roleid;
            return Save();
            
               

            
        }
        public bool Save()
        {
            var saved = _Context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
