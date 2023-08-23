using ProjectUpdateApp.Dto;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.IRepository
{
    public interface IUserProjectUpdateRepository
    {
        public ICollection<UserUpdateDetailsDto> GetProjectList();
        public ICollection<UserUpdateDetailsDto> GetProjectListByID(Guid UserID);
       
        public bool  CreateProjectUpdates(Guid id,ProjectUpdate projectUpdate);
        public bool UpdateDetails(Guid ProjectUpdateID, UserProjectUpdateDto projectUpdate);


        public bool DeleteProjectUpdate(Guid ProjectUpdateID);


        public ICollection<UserUpdateDetailsDto> SortingByDate();
        public ICollection<UserUpdateDetailsDto> SortingByProjectName();
        public ICollection<UserUpdateDetailsDto> SortingByProjectStatus();
        public ICollection<UserUpdateDetailsDto> ResourceNameFilter(string searchitem);
        public ICollection<UserUpdateDetailsDto> ProjectNameFilter(string searchitem);
        public ICollection<UserUpdateDetailsDto> ProjectStatusFilter(string searchitem);
        public ICollection<UserUpdateDetailsDto> DateFilter(DateTime searchitem);


    }
}
