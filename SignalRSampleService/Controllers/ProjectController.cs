using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalRSampleService.Contexts;
using SignalRSampleService.Dtos;
using System.Threading.Tasks;
using static SignalRSampleService.RabbitMq.Contracts.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace SignalRSampleService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectDetailContext _projectDetailContext;


        private readonly IPublishEndpoint _publishEndpoint;


        /// <summary>
        /// Initializes a new instance of the <seealso cref="ProjectController"/> WebAPI controller.
        /// </summary>
        /// <param name="projectDetailContext">Injectable custom <seealso cref="DbContext"/> instance for manaing project details.</param>
        public ProjectController(IPublishEndpoint publishEndpoint, ProjectDetailContext projectDetailContext)
        {
            _projectDetailContext = projectDetailContext;
            _publishEndpoint = publishEndpoint;
        }


        // GET: api/<ProjectController>
        [HttpGet]
        public async Task<ProjectDetail> Get()
        {
            var entity = await _projectDetailContext.ProjectDetail
                .AsNoTracking()
                .SingleOrDefaultAsync();

            return new ProjectDetail(entity.Name);
        }

        // PUT: api/<ProjectController>

        [HttpPut]
        public async Task<ProjectDetail> Put(ProjectDetailUpdate updateProjectDto)
        {

            await _publishEndpoint.Publish(new ProjectDetailUpdated(updateProjectDto.name));

            
            return new ProjectDetail("");
        }
    }
}
