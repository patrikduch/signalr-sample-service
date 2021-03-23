using AutoMapper;
using SignalRSampleService.Dtos;
using SignalRSampleService.Models;

namespace SignalRSampleService.Automapper.Profiles
{
    /// <summary>
    /// Mapping scanner configuration for CompanyModel objects.
    /// </summary>
    public class CompanyMapperProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <seealso cref="CompanyMapperProfile"/> class 
        /// and setup mapping configuration for  <seealso cref="CompanyModel"/>.
        /// </summary>
        public CompanyMapperProfile()
        {
            CreateMap<CompanyModel, CompanyItemDto>();
        }
    }
}
