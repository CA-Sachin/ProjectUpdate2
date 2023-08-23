using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectUpdateApp.IService;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserRoleController : Controller
    {

        private readonly IUserRoleService _userRoleService;
        private readonly IMapper _mapper;

        public UserRoleController(IUserRoleService userRoleService, IMapper mapper)
        {
            _userRoleService = userRoleService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllUserRole()
        {
          var k=  _userRoleService.GetAllUserRole();
            return Ok(k);

        }
        [HttpPost]
        public IActionResult MapUserRole(Guid Userid, Guid Roleid)
        {
            if(!_userRoleService.CreateUserRole(Userid, Roleid))
            {
                return NotFound("User or Role not found or already assigned ");
            }
            return Ok("User mapped to role successfully");
        }
        [HttpPut]
        public IActionResult UpdateUserRole(Guid Userid, Guid Roleid)
        {  

            if (!_userRoleService.UpdateUserRole(Userid, Roleid))
            {
                return NotFound("User or Role not found");
            }
            return Ok("User role has been updated successfully");
        }
        [HttpDelete]
        public IActionResult DeleteUserRole(Guid Userid,Guid Roleid)
        {
            if (!_userRoleService.DeleteUserRole(Userid, Roleid))
                return NotFound();

            return Ok("Deleted");
        }


    }
}
