using ProjectUpdateApp.Dto;
using ProjectUpdateApp.IRepository;
using ProjectUpdateApp.IService;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public bool CreateProject(Project project)
        {
            var p = new Project()
            {
                ProjectName = project.ProjectName,
                CreatedBy = "Admin",
                CreatedOn = DateTime.Now,
                IsDelete = false,




            };
            return _projectRepository.CreateProject(p);
        }

        public bool DeleteProject(Project project)
        {
            return _projectRepository.DeleteProject(project);
        }

        public ICollection<Project> GetAllProjects()
        {
           return _projectRepository.GetAllProjects();
        }

        public Project GetProjectbyId(Guid id)
        {
           return _projectRepository.GetProjectbyId(id);
        }

        public bool ProjectExists(Guid projectId)
        {
           return _projectRepository.ProjectExists(projectId);
        }

        public bool UpdateProject(Guid projectid, ProjectDto projectDto)
        {
            return _projectRepository.UpdateProject(projectid, projectDto);
        }
    }
}
