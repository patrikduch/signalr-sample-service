using SignalRSampleService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRSampleService.Repositories
{
    /// <summary>
    /// Contract for the Company repository data repository.
    /// </summary>
    public interface ICompanyRepository
    {
        Task<CompanyModel> Find(int id);

        Task<IEnumerable<CompanyModel>> GetAll();

        Task<CompanyModel> Add(CompanyModel company);

        Task<CompanyModel> Update(CompanyModel company);

        Task Remove(int id);
    }
}
