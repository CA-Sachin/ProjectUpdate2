using AutoMapper;
using ProjectUpdateApp.Dto;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.Mapper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
           
            CreateMap<UserDto,User>();
            CreateMap<User,UserDto>();
          
            CreateMap<ProjectUpdateDto,ProjectUpdate>();
            CreateMap<ProjectUpdate,ProjectUpdateDto>();
            CreateMap<Role,RoleDto>();
            CreateMap<RoleDto,Role>();
        }
    }
}
