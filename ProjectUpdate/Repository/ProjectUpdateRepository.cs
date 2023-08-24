using ProjectUpdateApp.Data;
using ProjectUpdateApp.Dto;
using ProjectUpdateApp.IRepository;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.Repository
{
    public class ProjectUpdateRepository : IProjectUpdateRepository
    {
        private readonly DataContext _dataContext;

        public ProjectUpdateRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool CreateProjectUpdate(ProjectUpdate p)
        {
              
            _dataContext.ProjectUpdate.Add(p);
           
             return Save();



        }

        public bool DeleteProjectUpdate(Guid id)
        {
            var p =_dataContext.ProjectUpdate.Where(x => x.ProjectUpdateID == id).FirstOrDefault();


            _dataContext.ProjectUpdate.Remove(p);
            
            return Save();  
        }

        public ProjectUpdateDto Getdetailsbyid(Guid ProjectUpdateId)
        {
            var p=_dataContext.ProjectUpdate.Where(x=>x.ProjectUpdateID== ProjectUpdateId).FirstOrDefault();
           


            var k = new ProjectUpdateDto()
            {
                ProjectName = p.ProjectName,
                TaskDetails = p.TaskDetails,
                NextPlan = p.NextPlan,
                Billinghrs = p.Billinghrs,
                ProjectStatus = p.ProjectStatus,
                Workinghrs = p.Workinghrs,
                UpdateDate = p.UpdateDate,
                Reasonoflessbilling=p.Reasonoflessbilling
                
               
            };
            return (k);
            

        }

        public bool ProjectUpdateExists(Guid ProjectUpdateId)
        {
           return _dataContext.ProjectUpdate.Any(x=>x.ProjectUpdateID == ProjectUpdateId);
        }

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateProjectDetails(Guid ProjectUpdateID, ProjectUpdateDto p)
        {
            var details= _dataContext.ProjectUpdate.Where(x => x.ProjectUpdateID == ProjectUpdateID).FirstOrDefault();
           
               details.ProjectName= p.ProjectName;
            details.ProjectStatus = p.ProjectStatus;
               details.TaskDetails= p.TaskDetails;
                details.Workinghrs= p.Workinghrs;
                details.Billinghrs= p.Billinghrs;
                details.NextPlan= p.NextPlan;
            details.UpdateDate= p.UpdateDate;
            details.Reasonoflessbilling= p.Reasonoflessbilling;

            return Save();

        }
    }
}
