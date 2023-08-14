using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectUpdateApp.Dto;
using ProjectUpdateApp.IService;

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
        [HttpPost]
        public IActionResult CreateProjectUpdate(Guid userid,UserProjectUpdateDto p)
        {


            if (!_userProjectUpdateService.CreateProjectUpdates(userid, p))
                return Ok("user not found");

            return Ok("successfully created");
        }
        [HttpPut]
        public IActionResult UpdateDetails(Guid ProjectUpdateID,UserProjectUpdateDto p)
        {
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
