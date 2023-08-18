using AutoMapper;
using ProjectUpdateApp.Dto;
using ProjectUpdateApp.IRepository;
using ProjectUpdateApp.IService;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.Service
{
    public class ProjectUpdateService : IProjectUpdateService
    {
        private readonly IProjectUpdateRepository _projectUpdateRepository;
        private readonly IMapper _mapper;

        public ProjectUpdateService(IProjectUpdateRepository projectUpdateRepository,IMapper mapper)
        {
            _projectUpdateRepository = projectUpdateRepository;
          _mapper = mapper;
        }

       

        public bool CreateProjectUpdate(ProjectUpdate projectUPdate)
        {    
                  
            
            var k = new ProjectUpdate()
            {     
                 
                ProjectName = projectUPdate.ProjectName,
                TaskDetails = projectUPdate.TaskDetails,
                Workinghrs = projectUPdate.Workinghrs,
                Billinghrs = projectUPdate.Billinghrs,
                NextPlan = projectUPdate.NextPlan,
                ProjectStatus = projectUPdate.ProjectStatus,
               UpdateDate = DateTime.Now,
                Reasonoflessbilling = "er",
             


            };
        

            return _projectUpdateRepository.CreateProjectUpdate(k);

                
        }

        public bool DeleteProjectUpdate(Guid id)
        {
            return _projectUpdateRepository.DeleteProjectUpdate(id);
        }

        public ProjectUpdateDto Getdetailsbyid(Guid ProjectUpdateId)
        {
            return _projectUpdateRepository.Getdetailsbyid(ProjectUpdateId);
        }

        public bool ProjectUpdateExists(Guid ProjectUpdateId)
        {
           return _projectUpdateRepository.ProjectUpdateExists(ProjectUpdateId);
        }

        public bool UpdateProjectDetails(Guid ProjectUpdateID, ProjectUpdateDto p)
        {
           return _projectUpdateRepository.UpdateProjectDetails(ProjectUpdateID, p);
        }
    }
}
