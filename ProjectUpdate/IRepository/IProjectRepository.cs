using ProjectUpdateApp.Dto;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.IRepository
{
    public interface IProjectRepository
    {
        ICollection<Project> GetAllProjects();
        Project GetProjectbyId(Guid id);

        bool ProjectExists(Guid projectId);

        bool CreateProject(Project projectDto);
        bool UpdateProject(Guid projectid, ProjectDto projectDto);
        bool DeleteProject(Project project);


    }
}
