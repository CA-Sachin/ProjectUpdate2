using ProjectUpdateApp.Dto;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.IService
{
    public interface IUserProjectService
    {
        ICollection<UserProjectDto> GetAllUserProject();
      //  UserProjectDto GetUserProjectbyId(Guid id);
        bool UserProjectExist(Guid id,Guid pid);
        public bool CreateUserProject(Guid userid, Guid Projectid);
        public bool UpdateUserProject(Guid userid, Guid Projectid);
        public bool DeleteUserProject(Guid id, Guid Projectid);
    }
}
