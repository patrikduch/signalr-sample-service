using SignalRSampleService.Dtos;
using System.Threading.Tasks;

namespace SignalRSampleService.Repositories
{
    /// <summary>
    /// Contract for the ProjectDetail data repository.
    /// </summary>
    public interface IProjectDetailRepository
    {
        Task<ProjectDetailDto> GetProjectDetail();

        Task UpdateProjectDetail(ProjectDetailUpdate projectDetailUpdate);
    }
}
