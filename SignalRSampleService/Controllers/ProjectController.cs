using Microsoft.AspNetCore.Mvc;
using SignalRSampleService.Dtos;
using SignalRSampleService.RabbitMq.Producer;
using SignalRSampleService.Repositories;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace SignalRSampleService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {

        private readonly IProjectDetailRepository _projectDetailRepository;
        private readonly IRabbitMqProducer _rabbitMqProducer;

        /// <summary>
        /// Initializes a new instance of the <seealso cref="ProjectController"/> WebAPI controller.
        /// </summary>
        /// <param name="projectDetailRepository">Injectable custom <seealso cref="IProjectDetailRepository"/> instance for manaing project details.</param>
        public ProjectController(IProjectDetailRepository projectDetailRepository, IRabbitMqProducer rabbitMqProducer)
        {
            _projectDetailRepository = projectDetailRepository;
            _rabbitMqProducer = rabbitMqProducer;
        }

        // GET: api/<ProjectController>
        [HttpGet]
        public async Task<ProjectDetailDto> Get()
        {
            var entity = await _projectDetailRepository.GetProjectDetail();

            return new ProjectDetailDto(entity.Name);
        }

        // PUT: api/<ProjectController>

        [HttpPut]
        public async Task<ProjectDetailDto> Put([FromBody] ProjectDetailUpdate updateProjectDto)
        {
            await _projectDetailRepository.UpdateProjectDetail(updateProjectDto);

            // _rabbitMqProducer.Publish($"Project detail has been updated! - > {updateProjectDto.Name}");

            return new ProjectDetailDto("");
        }
    }
}
