﻿using ProjectUpdateApp.Dto;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.IService
{
    public interface IUserProjectUpdateService
    {
        public ICollection<UserProjectUpdate> GetProjectList();
        public ICollection<UserProjectUpdate> GetProjectListByID(Guid UserID);


        public bool CreateProjectUpdates(Guid id, UserProjectUpdateDto  projectUpdate);
        public bool UpdateDetails(Guid ProjectUpdateID, UserProjectUpdateDto projectUpdate);
        public bool DeleteProjectUpdate(Guid ProjectUpdateID);



    }
}
