using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectUpdateApp.IService;

namespace ProjectUpdateApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProjectController : Controller
    {
        private readonly IUserProjectService _userProjectService;
        private readonly IMapper _mapper;

        public UserProjectController(IUserProjectService userProjectService, IMapper mapper)
        {
            _userProjectService = userProjectService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllUserProject()
        {
            var k = _userProjectService.GetAllUserProject();
            return Ok(k);

        }
        [HttpPost]
        public IActionResult MapUserProject(Guid Userid, Guid Projectid)
        {
            if (_userProjectService.UserProjectExist(Userid, Projectid))
                return NotFound("mapping already exist! ");

            if (!_userProjectService.CreateUserProject(Userid, Projectid))
            {
                return NotFound("User or Project not found ");
            }
            return Ok("User mapped to Project successfully");
        }
        [HttpPut]
        public IActionResult UpdateUserProject(Guid Userid, Guid Projectid)
        {
           

            if (!_userProjectService.UpdateUserProject(Userid, Projectid))
            {
                return NotFound("User or Project not found");
            }

            return Ok("User Project has been updated successfully");
        }
        [HttpDelete]
        public IActionResult DeleteUserProject(Guid Userid, Guid Projectid)
        {
            if (!_userProjectService.UserProjectExist(Userid, Projectid))
                return NotFound("mapping not found! ");

            _userProjectService.DeleteUserProject(Userid, Projectid);

            return Ok("Deleted");
        }
    }
}
