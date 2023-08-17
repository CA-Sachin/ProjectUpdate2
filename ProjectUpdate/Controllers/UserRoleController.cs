using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectUpdateApp.IService;

namespace ProjectUpdateApp.Controllers
{
    [Route("api/[controller]")]
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
        

       
    }
}
