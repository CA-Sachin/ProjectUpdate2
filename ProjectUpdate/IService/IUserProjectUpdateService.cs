﻿using ProjectUpdateApp.Dto;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.IService
{
    public interface IUserProjectUpdateService
    {
        public ICollection<UserUpdateDetailsDto> GetProjectList();
        public ICollection<UserUpdateDetailsDto> GetProjectListByID(Guid UserID);


        public bool CreateProjectUpdates(Guid id, UserProjectUpdateDto  projectUpdate);
        public bool UpdateDetails(Guid ProjectUpdateID, UserProjectUpdateDto projectUpdate);
        public bool DeleteProjectUpdate(Guid ProjectUpdateID);
        public ICollection<UserUpdateDetailsDto> FilterByDate();
        public ICollection<UserUpdateDetailsDto> FilterByProjectName();
        public ICollection<UserUpdateDetailsDto> FilterByProjectStatus();



    }
}
