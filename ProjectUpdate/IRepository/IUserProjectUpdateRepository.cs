﻿using ProjectUpdateApp.Dto;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.IRepository
{
    public interface IUserProjectUpdateRepository
    {
        public ICollection<UserUpdateDetailsDto> GetProjectList();
        public ICollection<UserUpdateDetailsDto> GetProjectListByID(Guid UserID);
       
        public bool  CreateProjectUpdates(Guid id,ProjectUpdate projectUpdate);
        public bool UpdateDetails(Guid ProjectUpdateID, UserProjectUpdateDto projectUpdate);


        public bool DeleteProjectUpdate(Guid ProjectUpdateID);


        public ICollection<UserUpdateDetailsDto> FilterByDate();
        public ICollection<UserUpdateDetailsDto> FilterByProjectName();
        public ICollection<UserUpdateDetailsDto> FilterByProjectStatus();


    }
}
