using ProjectUpdateApp.Dto;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.IRepository
{
    public interface IProjectUpdateRepository
    {
        public bool CreateProjectUpdate(ProjectUpdate pr);

        public ProjectUpdateDto Getdetailsbyid(Guid ProjectUpdateId);

        public bool ProjectUpdateExists(Guid ProjectUpdateId);
        public bool UpdateProjectDetails(Guid ProjectUpdateID, ProjectUpdateDto p);
        public bool DeleteProjectUpdate(Guid id );



    }
}
