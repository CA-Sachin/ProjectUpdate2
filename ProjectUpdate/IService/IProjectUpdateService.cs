using ProjectUpdateApp.Dto;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.IService
{
    public interface IProjectUpdateService
    {
        public bool CreateProjectUpdate(ProjectUpdate p);

        public ProjectUpdateDto Getdetailsbyid(Guid ProjectUpdateId);
        public bool ProjectUpdateExists(Guid ProjectUpdateId);
        public bool UpdateProjectDetails(Guid ProjectUpdateID, ProjectUpdateDto p);
        public bool DeleteProjectUpdate(Guid id);



    }
}
