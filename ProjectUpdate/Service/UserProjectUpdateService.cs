using ProjectUpdateApp.Dto;
using ProjectUpdateApp.IRepository;
using ProjectUpdateApp.IService;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.Service
{
    public class UserProjectUpdateService : IUserProjectUpdateService
    {
        private readonly IUserProjectUpdateRepository _userProjectUpdateRepository;

        public UserProjectUpdateService(IUserProjectUpdateRepository userProjectUpdateRepository)
        {
            _userProjectUpdateRepository = userProjectUpdateRepository;
        }

        public bool CreateProjectUpdates(Guid id, UserProjectUpdateDto projectUpdate)
        {
            var k = new ProjectUpdate
            {
                ProjectName = projectUpdate.ProjectName,
                TaskDetails = projectUpdate.TaskDetails,
                ProjectStatus = projectUpdate.ProjectStatus,
                Workinghrs = projectUpdate.Workinghrs,
                Billinghrs = projectUpdate.Billinghrs,
                UpdateDate = DateTime.UtcNow,
                NextPlan = projectUpdate.NextPlan,
                Reasonoflessbilling = "Ff"
            };
            return  _userProjectUpdateRepository.CreateProjectUpdates(id, k);
        }

        public bool DeleteProjectUpdate(Guid ProjectUpdateID)
        {
           return _userProjectUpdateRepository.DeleteProjectUpdate(ProjectUpdateID);
        }

        public ICollection<UserProjectUpdate> FilterByDate()
        {
            return _userProjectUpdateRepository.FilterByDate();
        }

        public ICollection<UserProjectUpdate> FilterByProjectName()
        {
            return _userProjectUpdateRepository.FilterByProjectName();

        }

        public ICollection<UserProjectUpdate> FilterByProjectStatus()
        {
            return _userProjectUpdateRepository.FilterByProjectStatus();
        }

        public ICollection<UserProjectUpdate> GetProjectList()
        {
          return _userProjectUpdateRepository.GetProjectList();
        }

        public ICollection<UserProjectUpdate> GetProjectListByID(Guid UserID)
        {
            return _userProjectUpdateRepository.GetProjectListByID(UserID);
        }

        public bool UpdateDetails(Guid ProjectUpdateID, UserProjectUpdateDto projectUpdate)
        {
           return _userProjectUpdateRepository.UpdateDetails(ProjectUpdateID, projectUpdate);
        }
    }
}
