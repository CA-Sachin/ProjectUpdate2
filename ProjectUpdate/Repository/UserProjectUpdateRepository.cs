using Microsoft.EntityFrameworkCore.Diagnostics;
using ProjectUpdateApp.Data;
using ProjectUpdateApp.Dto;
using ProjectUpdateApp.IRepository;
using ProjectUpdateApp.Models;
using System.Linq;

namespace ProjectUpdateApp.Repository
{
    public class UserProjectUpdateRepository : IUserProjectUpdateRepository
    {
        private readonly DataContext _dataContext;

        public UserProjectUpdateRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool CreateProjectUpdates(Guid id, ProjectUpdate projectUpdate)
        {
            
               

           var user=_dataContext.User.Where(x=>x.Id == id).FirstOrDefault();
            if(user == null)
            {
                return false;
            }

           

            var t = new UserProjectUpdate
            {
                Id = id,
                ProjectUpdate = projectUpdate,
                User = user
            };
            _dataContext.ProjectUpdate.Add(projectUpdate);
            _dataContext.UserProjectUpdate.Add(t);
            return Save();
        }

        public bool DeleteProjectUpdate(Guid ProjectUpdateID)
        {
            var p=_dataContext.ProjectUpdate.Where(x=>x.ProjectUpdateID == ProjectUpdateID).FirstOrDefault();

            _dataContext.ProjectUpdate.Remove(p);
            return Save();
        }

        public ICollection<UserUpdateDetailsDto> GetProjectList()
        {
       var userprojectupdates = (from upu in _dataContext.UserProjectUpdate
                                 join user in _dataContext.User on upu.Id equals user.Id
                                 join projectupdate in _dataContext.ProjectUpdate on upu.ProjectUpdateID equals projectupdate.ProjectUpdateID
                                select new UserUpdateDetailsDto
                                {
                                    Id = user.Id,
                                    ProjectUpdateID = projectupdate.ProjectUpdateID,
                                    Username = user.Username,
                                   
                                    ProjectName = projectupdate.ProjectName,
                                    TaskDetails = projectupdate.TaskDetails,
                                    ProjectStatus = projectupdate.ProjectStatus,
                                    Workinghrs = projectupdate.Workinghrs,
                                    Billinghrs = projectupdate.Billinghrs,
                                    NextPlan = projectupdate.NextPlan,
                                    UpdateDate = projectupdate.UpdateDate,
                                    Reasonoflessbilling=projectupdate.Reasonoflessbilling,
                                    


                                }).ToList();
                               
            return userprojectupdates;
                                
        }
        public ICollection<UserUpdateDetailsDto> SortingByDate()
        {

            var userprojectupdates = (from upu in _dataContext.UserProjectUpdate
                                      join user in _dataContext.User on upu.Id equals user.Id
                                      join projectupdate in _dataContext.ProjectUpdate on upu.ProjectUpdateID equals projectupdate.ProjectUpdateID
                                      orderby projectupdate.UpdateDate descending
                                      select new UserUpdateDetailsDto
                                      {

                                          Id = user.Id,
                                          ProjectUpdateID = projectupdate.ProjectUpdateID,
                                          Username = user.Username,
                                         // Role = user.Role,
                                          ProjectName = projectupdate.ProjectName,
                                          TaskDetails = projectupdate.TaskDetails,
                                          ProjectStatus = projectupdate.ProjectStatus,
                                          Workinghrs = projectupdate.Workinghrs,
                                          Billinghrs = projectupdate.Billinghrs,
                                          NextPlan = projectupdate.NextPlan,
                                          UpdateDate = projectupdate.UpdateDate,
                                          Reasonoflessbilling= projectupdate.Reasonoflessbilling,


                                      }).ToList();
            return userprojectupdates;

        }
        public ICollection<UserUpdateDetailsDto> SortingByProjectName()
        {
            var userprojects = (from upu in _dataContext.UserProjectUpdate
                                join user in _dataContext.User on upu.Id equals user.Id
                                join projectupdate in _dataContext.ProjectUpdate on upu.ProjectUpdateID equals projectupdate.ProjectUpdateID
                                orderby projectupdate.ProjectName ascending
                                select new UserUpdateDetailsDto
                                {

                                    Id = user.Id,
                                    ProjectUpdateID = projectupdate.ProjectUpdateID,
                                    Username = user.Username,
                                   // Role = user.Role,
                                    ProjectName = projectupdate.ProjectName,
                                    TaskDetails = projectupdate.TaskDetails,
                                    ProjectStatus = projectupdate.ProjectStatus,
                                    Workinghrs = projectupdate.Workinghrs,
                                    Billinghrs = projectupdate.Billinghrs,
                                    NextPlan = projectupdate.NextPlan,
                                    UpdateDate = projectupdate.UpdateDate,
                                    Reasonoflessbilling = projectupdate.Reasonoflessbilling,



                                }).ToList();
            return userprojects;
        }

        public ICollection<UserUpdateDetailsDto> SortingByProjectStatus()
        {
            var userprojects = (from upu in _dataContext.UserProjectUpdate
                                join user in _dataContext.User on upu.Id equals user.Id
                                join projectupdate in _dataContext.ProjectUpdate on upu.ProjectUpdateID equals projectupdate.ProjectUpdateID
                                orderby projectupdate.ProjectStatus ascending
                                select new UserUpdateDetailsDto
                                {

                                    Id = user.Id,
                                    ProjectUpdateID = projectupdate.ProjectUpdateID,
                                    Username = user.Username,
                                   // Role = user.Role,
                                    ProjectName = projectupdate.ProjectName,
                                    TaskDetails = projectupdate.TaskDetails,
                                    ProjectStatus = projectupdate.ProjectStatus,
                                    Workinghrs = projectupdate.Workinghrs,
                                    Billinghrs = projectupdate.Billinghrs,
                                    NextPlan = projectupdate.NextPlan,
                                    UpdateDate = projectupdate.UpdateDate,
                                    Reasonoflessbilling= projectupdate.Reasonoflessbilling,


                                }).ToList();
            return userprojects;
        }

        public ICollection<UserUpdateDetailsDto> GetProjectListByID(Guid UserID)
        {
            var x = _dataContext.User.Where(x => x.Id == UserID).FirstOrDefault();

            var p = _dataContext.UserProjectUpdate.Where(x => x.Id == UserID).FirstOrDefault();

            

           


                var userprojectupdates = (from upu in _dataContext.UserProjectUpdate
                                          join user in _dataContext.User on upu.Id equals user.Id
                                          join projectupdate in _dataContext.ProjectUpdate on upu.ProjectUpdateID equals projectupdate.ProjectUpdateID
                                          where upu.Id == UserID
                                          select new UserUpdateDetailsDto
                                          {
                                              Id = UserID,
                                              ProjectUpdateID = projectupdate.ProjectUpdateID,
                                              Username=x.Username,
                                             // Role=x.Role,
                                              ProjectName=projectupdate.ProjectName,
                                              TaskDetails=projectupdate.TaskDetails,
                                              ProjectStatus=projectupdate.ProjectStatus,
                                              Workinghrs=projectupdate.Workinghrs,
                                              Billinghrs=projectupdate.Billinghrs,
                                              NextPlan=projectupdate.NextPlan,
                                              UpdateDate=projectupdate.UpdateDate, 
                                              Reasonoflessbilling=projectupdate.Reasonoflessbilling,
                                          }).ToList();


                return userprojectupdates;
           

        }

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateDetails(Guid ProjectUpdateID, UserProjectUpdateDto projectUpdate)
        {
          var p=_dataContext.ProjectUpdate.Where(x=>x.ProjectUpdateID== ProjectUpdateID).FirstOrDefault();
            if(p==null) return false;

            p.ProjectName= projectUpdate.ProjectName;
            p.TaskDetails= projectUpdate.TaskDetails;
            p.ProjectStatus=projectUpdate.ProjectStatus;
            p.Workinghrs= projectUpdate.Workinghrs;
            p.Billinghrs= projectUpdate.Billinghrs;
            p.UpdateDate = DateTime.Now;


            return Save();
        }

        public ICollection<UserUpdateDetailsDto> ProjectNameFilter(string searchitem)
        {
            var userprojects = (from upu in _dataContext.UserProjectUpdate
                                join user in _dataContext.User on upu.Id equals user.Id
                                join projectupdate in _dataContext.ProjectUpdate on upu.ProjectUpdateID equals projectupdate.ProjectUpdateID
                                orderby projectupdate.ProjectName ascending
                                select new UserUpdateDetailsDto
                                {
                                    Id = user.Id,
                                    ProjectUpdateID = projectupdate.ProjectUpdateID,
                                    Username = user.Username,
                                    ProjectName = projectupdate.ProjectName,
                                    TaskDetails = projectupdate.TaskDetails,
                                    ProjectStatus = projectupdate.ProjectStatus,
                                    Workinghrs = projectupdate.Workinghrs,
                                    Billinghrs = projectupdate.Billinghrs,
                                    NextPlan = projectupdate.NextPlan,
                                    UpdateDate = projectupdate.UpdateDate,
                                    Reasonoflessbilling = projectupdate.Reasonoflessbilling,
                                }).ToList();

            var filteredUserProjects = userprojects
                .Where(p => p.ProjectName.Contains(searchitem, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return filteredUserProjects;
        }

        public ICollection<UserUpdateDetailsDto> ProjectStatusFilter(string searchitem)
        {
            var userprojects = (from upu in _dataContext.UserProjectUpdate
                                join user in _dataContext.User on upu.Id equals user.Id
                                join projectupdate in _dataContext.ProjectUpdate on upu.ProjectUpdateID equals projectupdate.ProjectUpdateID
                                orderby projectupdate.ProjectStatus ascending
                                select new UserUpdateDetailsDto
                                {
                                    Id = user.Id,
                                    ProjectUpdateID = projectupdate.ProjectUpdateID,
                                    Username = user.Username,
                                    ProjectName = projectupdate.ProjectName,
                                    TaskDetails = projectupdate.TaskDetails,
                                    ProjectStatus = projectupdate.ProjectStatus,
                                    Workinghrs = projectupdate.Workinghrs,
                                    Billinghrs = projectupdate.Billinghrs,
                                    NextPlan = projectupdate.NextPlan,
                                    UpdateDate = projectupdate.UpdateDate,
                                    Reasonoflessbilling = projectupdate.Reasonoflessbilling,
                                }).ToList();

            var filteredUserProjects = userprojects
                .Where(p => p.ProjectStatus.Contains(searchitem, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return filteredUserProjects;
        }

        public ICollection<UserUpdateDetailsDto> DateFilter(DateTime searchitem)
        {
            var userprojects = (from upu in _dataContext.UserProjectUpdate
                                join user in _dataContext.User on upu.Id equals user.Id
                                join projectupdate in _dataContext.ProjectUpdate on upu.ProjectUpdateID equals projectupdate.ProjectUpdateID
                                orderby projectupdate.UpdateDate ascending
                                select new UserUpdateDetailsDto
                                {
                                    Id = user.Id,
                                    ProjectUpdateID = projectupdate.ProjectUpdateID,
                                    Username = user.Username,
                                    ProjectName = projectupdate.ProjectName,
                                    TaskDetails = projectupdate.TaskDetails,
                                    ProjectStatus = projectupdate.ProjectStatus,
                                    Workinghrs = projectupdate.Workinghrs,
                                    Billinghrs = projectupdate.Billinghrs,
                                    NextPlan = projectupdate.NextPlan,
                                    UpdateDate = projectupdate.UpdateDate,
                                    Reasonoflessbilling = projectupdate.Reasonoflessbilling,
                                }).ToList();

            var filteredUserProjects = userprojects
                .Where(p => p.UpdateDate.Date==searchitem.Date)
                .ToList();

            return filteredUserProjects;
        }
    }
}
