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
        public bool CreateUserProject(Guid userid, List<Guid> Projectid)
        {
            var user = _Context.User.Find(userid);


            if (user == null)
            {
                return false;
            }


            foreach (var projectId in Projectid)
            {
                var existingMapping = _Context.UserProject.FirstOrDefault(up => up.Userid == userid && up.Projectid == projectId);

                if (existingMapping == null)
                {

                    var project = _Context.Project.Find(projectId);
                    if (project != null)
                    {
                        var userProjectMapping = new UserProject
                        {
                            Userid = userid,
                            Projectid = projectId,
                            IsDelete = false,
                            CreatedOn = DateTime.UtcNow,
                            CreatedBy = "Admin"
                        };
                        _Context.UserProject.Add(userProjectMapping);
                    }
                }
            }
            return Save();
        }

        public bool DeleteUserProject(Guid userid)
        {

            var userprojects = _Context.UserProject.Where(x => x.Userid == userid).ToList();
            if (userprojects.Count == 0) { return false; }

            _Context.UserProject.RemoveRange(userprojects);
            return Save();

        }

        public ICollection<UserProjectDto> GetAllUserProject()
        {
            var userProjects = _Context.UserProject.ToList();

            var userProjectsGrouped = userProjects
          .GroupBy(up => up.Userid)
          .Select(group => new UserProjectDto
          {
              Userid = group.Key,
              UserName = _Context.User.FirstOrDefault(u => u.Id == group.Key)?.Username,
              Projectid = group.Select(up => up.Projectid).ToList(),
              ProjectName = string.Join(", ", group.Select(up => _Context.Project.FirstOrDefault(p => p.ProjectId == up.Projectid)?.ProjectName))
          })
          .ToList();

            return userProjectsGrouped;
        }


        public bool UpdateUserProject(Guid userid, List<Guid> Projectids)
        {
            var ur = _Context.UserProject.Where(x => x.Userid == userid).FirstOrDefault();


            if (ur == null) { return false; }

            var existingMappings = _Context.UserProject.Where(up => up.Userid == userid);
            _Context.UserProject.RemoveRange(existingMappings);

            foreach (var projectId in Projectids)
            {
                var project = _Context.Project.Find(projectId);

                if (project != null)
                {
                    var newUserProjectMapping = new UserProject
                    {
                        Userid = userid,
                        Projectid = projectId,
                        IsDelete = false,
                        CreatedOn = DateTime.UtcNow,
                        CreatedBy = "Admin"
                    };

                    _Context.UserProject.Add(newUserProjectMapping);
                }
            }
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
