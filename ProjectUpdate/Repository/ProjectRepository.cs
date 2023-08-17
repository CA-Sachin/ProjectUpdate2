using Microsoft.EntityFrameworkCore;
using ProjectUpdateApp.Data;
using ProjectUpdateApp.Dto;
using ProjectUpdateApp.IRepository;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext _dataContext;

        public ProjectRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool CreateProject(Project project)
        {
             _dataContext.Project.Add(project);
            return Save();
        }

        public bool DeleteProject(Project project)
        {
            _dataContext.Project.Remove(project);
            return Save();

        }

        public ICollection<Project> GetAllProjects()
        {
           return  _dataContext.Project.ToList();
        }

        public Project GetProjectbyId(Guid id)
        {
            return _dataContext.Project.Where(x => x.ProjectId == id).FirstOrDefault();
        }

        public bool ProjectExists(Guid projectId)
        {
           return _dataContext.Project.Any(x=> x.ProjectId == projectId);
        }

        public bool UpdateProject(Guid projectid, ProjectDto projectDto)
        {
            var project = _dataContext.Project.Where(x => x.ProjectId == projectid).FirstOrDefault();

            project.ProjectName = projectDto.ProjectName;
            return Save();
        }

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
