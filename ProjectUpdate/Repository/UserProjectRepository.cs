﻿using ProjectUpdateApp.Data;
using ProjectUpdateApp.Dto;
using ProjectUpdateApp.IRepository;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.Repository
{
    public class UserProjectRepository:IUserProjectRepository
    {
        private readonly DataContext _Context;

        public UserProjectRepository(DataContext Context)
        {

            _Context = Context;
        }
        public bool CreateUserProject(Guid userid, Guid Projectid)
        {
            var user = _Context.User.Find(userid);
            var Project = _Context.Project.Find(Projectid);

            if (user == null || Project == null)
            {
                return false;
            }


            var userProjectMapping = new UserProject
            {
                Userid = userid,
                Projectid = Projectid,
                IsDelete = false,
                CreatedOn = DateTime.UtcNow,
                CreatedBy = "Admin"

            };

            _Context.UserProject.Add(userProjectMapping);
            return Save();

        }

        public bool DeleteUserProject(Guid userid, Guid Projectid)
        {
            var ur = _Context.UserProject.Where(x => x.Userid == userid && x.Projectid == Projectid).FirstOrDefault();
            
           

            _Context.UserProject.Remove(ur);
            
            return Save();

        }

        public ICollection<UserProjectDto> GetAllUserProject()
        {
            var userProjects = _Context.UserProject.ToList();

            var userProjectsGrouped = userProjects
          .GroupBy(up => up.Userid)
          .Select(group => new UserProjectDto
          {
              Userid = group.Key,
              UserName = _Context.User.FirstOrDefault(u => u.Id == group.Key)?.Username,
              Projectid = group.Select(up => up.Projectid).ToList(),
              ProjectName = string.Join(", ", group.Select(up => _Context.Project.FirstOrDefault(p => p.ProjectId == up.Projectid)?.ProjectName))
          })
          .ToList();

            return userProjectsGrouped;
        }


        public bool UpdateUserProject(Guid userid, Guid Projectid)
        {
            var ur = _Context.UserProject.Where(x => x.Userid == userid).FirstOrDefault();
           

        if(ur==null) { return false; }
         _Context.UserProject.Remove(ur);

            var userProjectMapping = new UserProject
            {
                Userid = userid,
                Projectid = Projectid,
                IsDelete = false,
                CreatedOn = DateTime.UtcNow,
                CreatedBy = "Admin"

            };
            _Context.UserProject.Add(userProjectMapping);
            return Save();




        }

        public bool UserProjectExist(Guid id,Guid pid)
        {
            return _Context.UserProject.Any(p => p.Userid == id && p.Projectid == pid);
        }
        public bool Save()
        {
            var saved = _Context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
