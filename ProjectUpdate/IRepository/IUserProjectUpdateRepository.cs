using ProjectUpdateApp.Dto;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.IRepository
{
    public interface IUserProjectUpdateRepository
    {
        public ICollection<UserProjectUpdate> GetProjectList();
        public ICollection<UserProjectUpdate> GetProjectListByID(Guid UserID);
       
        public bool  CreateProjectUpdates(Guid id,ProjectUpdate projectUpdate);
        public bool UpdateDetails(Guid ProjectUpdateID, UserProjectUpdateDto projectUpdate);
        public bool DeleteProjectUpdate(Guid ProjectUpdateID);


    }
}
