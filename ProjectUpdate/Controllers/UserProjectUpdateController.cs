using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectUpdateApp.Dto;
using ProjectUpdateApp.IService;
using ProjectUpdateApp.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ProjectUpdateApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProjectUpdateController : Controller
    {
        private readonly IUserProjectUpdateService _userProjectUpdateService;
        private readonly IMapper _mapper;

        public UserProjectUpdateController(IUserProjectUpdateService userProjectUpdateService,IMapper mapper)
        {
            _userProjectUpdateService = userProjectUpdateService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllProjectList()
        {
            var user = _userProjectUpdateService.GetProjectList();
            return Ok(user);
        }

        [HttpGet("{userid}")]
        public IActionResult GetAllProjectListByID(Guid userid)
        {
            var user = _userProjectUpdateService.GetProjectListByID(userid);
            
          

            return Ok(user);
        }

        [HttpGet("api/UserProjectUpdate/FilterByDate")]
        public IActionResult FilterByDate()
        {
            var k = _userProjectUpdateService.FilterByDate();
            return Ok(k);

        }

        [HttpGet("api/UserProjectUpdate/FilterByName")]
        public IActionResult FilterByName()
        {
            var k = _userProjectUpdateService.FilterByProjectName();
            return Ok(k);

        }
        [HttpGet("api/UserProjectUpdate/FilterByProjectStatus")]
        public IActionResult FilterByProjectStatus()
        {
            var k = _userProjectUpdateService.FilterByProjectStatus();
            return Ok(k);

        }
        [HttpPost("{userid}")]
        public IActionResult CreateProjectUpdate(Guid userid,UserProjectUpdateDto p)
        {
            if (p == null)
            {
                return BadRequest(ModelState); 
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_userProjectUpdateService.CreateProjectUpdates(userid, p))
                return Ok("user not found");

            return Ok("successfully created");
        }

        [HttpPut("{ ProjectUpdateID}")]
        public IActionResult UpdateDetails(Guid ProjectUpdateID,UserProjectUpdateDto p)
        {   if (p == null)
            {
                return Ok("All field required!");
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

           if(! _userProjectUpdateService.UpdateDetails(ProjectUpdateID,p))
                return BadRequest(ModelState);

               return Ok("Detailas updated");
        }
        [HttpDelete]
        public IActionResult DeleteProjectUpdate(Guid ProjectUpdateID) {
                    
           _userProjectUpdateService.DeleteProjectUpdate(ProjectUpdateID) ;

            return Ok("Project Update Deleted!");

        }


    }
}
