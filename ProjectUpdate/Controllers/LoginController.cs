using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectUpdateApp.Dto;
using ProjectUpdateApp.IService;
using ProjectUpdateApp.Service;

namespace ProjectUpdateApp.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class LoginController : Controller
    {

        private readonly ILoginService _loginService;
        private readonly IMapper _mapper;

        public LoginController(ILoginService loginService, IMapper mapper)
        {
            _loginService = loginService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult LoginUser([FromBody] LoginDto user)
        {

            if (user == null)
                return BadRequest(ModelState);



            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _loginService.UserLogin(user);
            if (result == "Invalid User")
            {
                ModelState.AddModelError("", "Something went wrong while Login");
                return StatusCode(500, ModelState);
            }
            return Ok(result);



        }
    }


   
}
