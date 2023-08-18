using ProjectUpdateApp.Data;
using ProjectUpdateApp.Dto;
using ProjectUpdateApp.IRepository;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.Repository
{
    public class UserProjectRepository:IUserProjectRepository
    {
        private readonly DataContext _Context;

        public UserProjectRepository(DataContext Context)
        {

            _Context = Context;
        }
        public bool CreateUserProject(Guid userid, Guid Projectid)
        {
            var user = _Context.User.Find(userid);
            var Project = _Context.Project.Find(Projectid);

            if (user == null || Project == null)
            {
                return false;
            }


            var userProjectMapping = new UserProject
            {
                Userid = userid,
                Projectid = Projectid,
                IsDelete = false,
                CreatedOn = DateTime.UtcNow,
                CreatedBy = "Admin"

            };

            _Context.UserProject.Add(userProjectMapping);
            return Save();

        }

        public bool DeleteUserProject(Guid userid, Guid Projectid)
        {
            var uid = _Context.UserProject.Where(x => x.Userid == userid).FirstOrDefault();
            var rid = _Context.UserProject.Where(x => x.Projectid == Projectid).FirstOrDefault();


            _Context.UserProject.Remove(uid);
            _Context.UserProject.Remove(rid);
            return Save();

        }

        public ICollection<UserProject> GetAllUserProject()
        {
            return _Context.UserProject.ToList();
        }


        public bool UpdateUserProject(Guid userid, Guid Projectid)
        {
            var ur = _Context.UserProject.Where(x => x.Userid == userid).FirstOrDefault();
            var pid =_Context.Project.Where(x=>x.ProjectId == Projectid).FirstOrDefault();

         if(ur==null || pid ==null) { return false; }

            ur.Projectid = Projectid;
            return Save();




        }

        public bool UserProjectExist(Guid id,Guid pid)
        {
            return _Context.UserProject.Any(p => p.Userid == id && p.Projectid == pid);
        }
        public bool Save()
        {
            var saved = _Context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
