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
                Reasonoflessbilling = projectUpdate.Reasonoflessbilling
            };
            return  _userProjectUpdateRepository.CreateProjectUpdates(id, k);
        }

        public bool DeleteProjectUpdate(Guid ProjectUpdateID)
        {
           return _userProjectUpdateRepository.DeleteProjectUpdate(ProjectUpdateID);
        }

        public ICollection<UserUpdateDetailsDto> GetProjectList()
        {
          return _userProjectUpdateRepository.GetProjectList();
        }
        public ICollection<UserUpdateDetailsDto> SortingByDate()
        {
            return _userProjectUpdateRepository.SortingByDate();
        }

        public ICollection<UserUpdateDetailsDto> SortingByProjectName()
        {
            return _userProjectUpdateRepository.SortingByProjectName();

        }

        public ICollection<UserUpdateDetailsDto> SortingByProjectStatus()
        {
            return _userProjectUpdateRepository.SortingByProjectStatus();
        }
        public ICollection<UserUpdateDetailsDto> GetProjectListByID(Guid UserID)
        {
            return _userProjectUpdateRepository.GetProjectListByID(UserID);
        }

        public bool UpdateDetails(Guid ProjectUpdateID, UserProjectUpdateDto projectUpdate)
        {
           return _userProjectUpdateRepository.UpdateDetails(ProjectUpdateID, projectUpdate);
        }

        public ICollection<UserUpdateDetailsDto> ProjectNameFilter(string searchitem)
        {
           return _userProjectUpdateRepository.ProjectNameFilter(searchitem);
        }

        public ICollection<UserUpdateDetailsDto> ProjectStatusFilter(string searchitem)
        {
           return _userProjectUpdateRepository.ProjectStatusFilter(searchitem);
        }

        public ICollection<UserUpdateDetailsDto> DateFilter(DateTime searchitem)
        {
            return _userProjectUpdateRepository.DateFilter(searchitem);
        }
    }
}
