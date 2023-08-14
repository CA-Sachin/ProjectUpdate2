using Microsoft.AspNetCore.Identity;
using ProjectUpdateApp.Dto;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.IRepository
{
    public interface IUserProjectUpdateRepository
    {
        public ICollection<UserProjectUpdate> GetProjectList();
        public ICollection<UserProjectUpdate> GetProjectListByID(Guid ProjectUpdateID);
        public ICollection<UserProjectUpdate> FilterByDate();
        public ICollection<UserProjectUpdate> FilterByProjectName();
        public ICollection<UserProjectUpdate> FilterByProjectStatus();
       
       
       
        public bool  CreateProjectUpdates(Guid id,ProjectUpdate projectUpdate);
        public bool UpdateDetails(Guid ProjectUpdateID, UserProjectUpdateDto projectUpdate);
        public bool DeleteProjectUpdate(Guid ProjectUpdateID);


    }
}
