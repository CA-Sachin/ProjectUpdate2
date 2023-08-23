using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectUpdateApp.IService;

namespace ProjectUpdateApp.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
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
        public IActionResult MapUserProject(Guid Userid, List<Guid> Projectid)
        {
           

            if (!_userProjectService.CreateUserProject(Userid, Projectid))
            {
                return NotFound("User or Project not found pr mapping exist");
            }
            return Ok("User mapped to Project successfully");
        }
        [HttpPut]
        public IActionResult UpdateUserProject(Guid Userid, List<Guid> Projectid)
        {
           

            if (!_userProjectService.UpdateUserProject(Userid, Projectid))
            {
                return NotFound("User or Project not found");
            }

            return Ok("User Project has been updated successfully");
        }
        [HttpDelete]
        public IActionResult DeleteUserProject(Guid Userid)
        {


            if (!_userProjectService.DeleteUserProject(Userid))
                return Ok("not found!");

            return Ok("Deleted");
        }
    }
}
