using AutoMapper;
using SignalRSampleService.Dtos;
using SignalRSampleService.Models;

namespace SignalRSampleService.Automapper.Profiles
{
    /// <summary>
    /// Mapping scanner configuration for ProjectDetail objects.
    /// </summary>
    public class ProjectDetailMapperProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <seealso cref="ProjectDetailMapperProfile"/> class 
        /// and setup mapping configuration for  <seealso cref="ProjectDetailModel"/>.
        /// </summary>
        public ProjectDetailMapperProfile()
        {
            CreateMap<ProjectDetailModel, ProjectDetailUpdateDto>();
            CreateMap<ProjectDetailModel, ProjectDetailDto>();
        }
    }
}
