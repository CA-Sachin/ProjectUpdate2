using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectUpdateApp.Dto;
using ProjectUpdateApp.IService;
using ProjectUpdateApp.Models;
using ProjectUpdateApp.Service;
using System.ComponentModel;
using System.Security.Claims;

namespace ProjectUpdateApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProjectUpdateController : Controller
    {
        private readonly IProjectUpdateService _projectUpdateService;
        private readonly IMapper _mapper;

        public ProjectUpdateController(IProjectUpdateService projectUpdateService, IMapper mapper)
        {
            _projectUpdateService = projectUpdateService;
            _mapper = mapper;
        }
        // Inside one of your API controller actions



        [HttpPost]
        public IActionResult CreateProjectUpdate([FromBody] ProjectUpdateDto projectupdatedto)

        {    
           
            if (!ModelState.IsValid)
            {
                return BadRequest("invalid entry");
            }
             var projectmap = _mapper.Map<ProjectUpdate>(projectupdatedto);
            //projectmap.Id= new Guid(userId);
           

            _projectUpdateService.CreateProjectUpdate(projectmap);


            return Ok("Project update created successfully");

        }
        [HttpGet("{ProjectUpdateId}")]
        public IActionResult Getdetailsbyid(Guid ProjectUpdateId)
        {
            if (!_projectUpdateService.ProjectUpdateExists(ProjectUpdateId))
            {
                return Ok("ID not found!");
            }
            var task = _projectUpdateService.Getdetailsbyid(ProjectUpdateId);

            return Ok(task);
        }

        [HttpPut("{ProjectUpdateID}")]
        public IActionResult UpdateProjectDetails(Guid ProjectUpdateID,ProjectUpdateDto p)
        {
           
            {
                if (!_projectUpdateService.ProjectUpdateExists(ProjectUpdateID))
                    return Ok("Id not found!");
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _projectUpdateService.UpdateProjectDetails(ProjectUpdateID, p);
                return Ok("Details Updated sucessfully!");

            }
        }

        
        [HttpDelete("{Id}")]
        public ActionResult DeleteProject(Guid Id)
        {
            if (!_projectUpdateService.ProjectUpdateExists(Id))
                return Ok("Id not found!");



            _projectUpdateService.DeleteProjectUpdate(Id);


            return Ok("Details Deleted");
        }
    }
}
