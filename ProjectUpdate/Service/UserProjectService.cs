using ProjectUpdateApp.Dto;
using ProjectUpdateApp.IRepository;
using ProjectUpdateApp.IService;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.Service
{
    public class UserProjectService:IUserProjectService
    {
        private readonly IUserProjectRepository _userProjectRepository;

        public UserProjectService(IUserProjectRepository userProjectRepository)
        {
            _userProjectRepository = userProjectRepository;
        }
        public bool CreateUserProject(Guid userid, Guid Projectid)
        {
            return _userProjectRepository.CreateUserProject(userid, Projectid);
        }

        public bool DeleteUserProject(Guid id, Guid Projectid)
        {
            return _userProjectRepository.DeleteUserProject(id, Projectid);
        }

        public ICollection<UserProjectDto> GetAllUserProject()
        {
            return _userProjectRepository.GetAllUserProject();
        }

        

        public bool UpdateUserProject(Guid id, Guid Projectid)
        {
            return _userProjectRepository.UpdateUserProject(id, Projectid);
        }

        public bool UserProjectExist(Guid id,Guid pid)
        {
            return _userProjectRepository.UserProjectExist(id,pid);
        }
    }
}
