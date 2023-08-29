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

        public ICollection<UserRoleDto> GetUserRolebyId(Guid id)
        {
            var userrole = (from userRole in _Context.UserRole
                            join user in _Context.User on userRole.Userid equals user.Id
                            join role in _Context.Role on userRole.Roleid equals role.RoleId
                            where userRole.Userid == id
                            select new UserRoleDto
                            {
                                Username = user.Username,
                                RoleName = role.RoleName,
                                Userid = user.Id,
                                Roleid = role.RoleId

                            }).ToList();
             return userrole;
        }

        public bool UpdateUserRole(Guid userid, Guid roleid)
        {   
            var ur=_Context.UserRole.Where(x=>x.Userid==userid).FirstOrDefault();

            if (ur == null) { return false; }

            _Context.UserRole.Remove(ur);

            var userRoleMapping = new UserRole
            {
                Userid = userid,
                Roleid = roleid,
                IsDelete = false,
                CreatedOn = DateTime.UtcNow,
                CreatedBy = "Admin"

            };
            _Context.UserRole.Add(userRoleMapping);
            return Save();
         
           






        }
        public bool Save()
        {
            var saved = _Context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
