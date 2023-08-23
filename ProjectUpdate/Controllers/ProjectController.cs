using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectUpdateApp.Dto;
using ProjectUpdateApp.IService;
using ProjectUpdateApp.Models;
using ProjectUpdateApp.Service;

namespace ProjectUpdateApp.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService projectService,IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            var p = _projectService.GetAllProjects();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(p);

        }
        [HttpGet("{projectId}")]
        public IActionResult GetProjectbyId(Guid projectId)
        {
            if (!_projectService.ProjectExists(projectId))
                return NotFound();

            var user = _mapper.Map<Project>(_projectService.GetProjectbyId(projectId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(user);

        }
        [HttpPost]
        public IActionResult CreateProject([FromBody] ProjectDto p)
        {
            if (p == null)
                return BadRequest(ModelState);



            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userMap = _mapper.Map<Project>(p);


            _projectService.CreateProject(userMap);


            return Ok("Successfully created");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProject([FromRoute] Guid id, [FromBody] ProjectDto updatedproject)
        {

            if (updatedproject == null)
                return BadRequest(ModelState);


            if (!_projectService.ProjectExists(id))
                return NotFound();



            if (!_projectService.UpdateProject(id, updatedproject))
            {
                ModelState.AddModelError("", "Something went wrong updating project");
                return StatusCode(500, ModelState);
            }

            return Ok("Project updated");


        }
        [HttpDelete("{projectId}")]
        public IActionResult DeleteProject(Guid projectId)
        {
            if (!_projectService.ProjectExists(projectId))
            {
                return NotFound();
            }

            var project = _projectService.GetProjectbyId(projectId);



            if (!_projectService.DeleteProject(project))
            {
                ModelState.AddModelError("", "Something went wrong deleting project");
            }

            return Ok("Deleted");
        }  }
}
