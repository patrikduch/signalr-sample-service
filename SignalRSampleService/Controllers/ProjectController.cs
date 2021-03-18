using Microsoft.AspNetCore.Mvc;
using Net5WebAPI.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace Net5WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        // GET: api/<ProjectController>
        [HttpGet]
        public ProjectDetail Get()
        {
            return new ProjectDetail("Project name");
        }
    }
}
