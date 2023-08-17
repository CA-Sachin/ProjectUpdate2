using ProjectUpdateApp.Dto;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.IService
{
    public interface IProjectService
    {
        ICollection<Project> GetAllProjects();
        Project GetProjectbyId(Guid id);

        bool ProjectExists(Guid projectId);

        bool CreateProject(Project projectDto);
        bool UpdateProject(Guid projectid, ProjectDto projectDto);
        bool DeleteProject(Project project);
    }
}
