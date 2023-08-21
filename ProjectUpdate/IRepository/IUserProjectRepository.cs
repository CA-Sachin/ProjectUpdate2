using ProjectUpdateApp.Dto;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.IRepository
{
    public interface IUserProjectRepository
    {
        ICollection<UserProjectDto> GetAllUserProject();
      //UserProjectDto GetUserProjectbyId(Guid id,Guid pid);
        bool UserProjectExist(Guid id,Guid projectid);
        public bool CreateUserProject(Guid userid, List<Guid> Projectid);
        public bool UpdateUserProject(Guid userid, List<Guid> Projectid);
        public bool DeleteUserProject(Guid id);
    }
}
