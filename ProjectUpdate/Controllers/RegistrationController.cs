using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectUpdateApp.Dto;
using ProjectUpdateApp.IService;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public RegistrationController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult getalluser()
        {

            //var map= _mapper.Map<List<RegistrationDto>>(_registrationService.GetRegistration)();
            var map = _mapper.Map<List<UserDto>>(_userService.GetRegistration());

            return Ok(map);

        }
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDto userCreate)
        {
            if (userCreate == null)
                return BadRequest(ModelState);



            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userMap = _mapper.Map<User>(userCreate);


            if (!_userService.CreateUser(userMap))
                return Ok("Email already Exist");


            return Ok("Successfully created");
        }
        [HttpPut]
        public IActionResult UpdateUser(Guid userId, [FromBody] UserDto updatedUser)
        {
            bool isValid = true;
            bool isUpdated = false;

            if (updatedUser == null)
            {
                isValid = false;
                ModelState.AddModelError("", "Updated user is null");
            }

            if (isValid && !_userService.UserExists(userId))
            {
                isValid = false;
                ModelState.AddModelError("", "User not found");
            }

            if (isValid && !ModelState.IsValid)
            {
                isValid = false;
            }

            if (isValid)
            {
                var userMap = _mapper.Map<User>(updatedUser);
                isUpdated = _userService.UpdateUser(userId, userMap);

                if (!isUpdated)
                {
                    ModelState.AddModelError("", "Something went wrong while updating user");
                    return StatusCode(500, ModelState);
                }
            }

            if (!isValid)
            {
                return BadRequest(ModelState);
            }



            return Ok("Details updated");
        }
        [HttpGet("{email}")]
        public IActionResult GetDetails(string email)
        {
            var t=_userService.GetDetils(email);
            return Ok(t);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetUserbyId(Guid userId)
        {
            if (!_userService.UserExists(userId))
                return NotFound();

            var user = _mapper.Map<UserDto>(_userService.GetUserbyId(userId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(user);

        }
    }
}
