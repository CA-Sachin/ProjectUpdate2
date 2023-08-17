using ProjectUpdateApp.Dto;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.IRepository
{
    public interface IUserProjectRepository
    {
        ICollection<UserProject> GetAllUserProject();
      //UserProjectDto GetUserProjectbyId(Guid id,Guid pid);
        bool UserProjectExist(Guid id,Guid projectid);
        public bool CreateUserProject(Guid userid, Guid Projectid);
        public bool UpdateUserProject(Guid userid, Guid Projectid);
        public bool DeleteUserProject(Guid id, Guid Projectid);
    }
}
