using Microsoft.EntityFrameworkCore;
using SignalRSampleService.Data;
using SignalRSampleService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRSampleService.Repositories
{
    /// <summary>
    /// EFCore repository for managing <seealso cref="CompanyModel"/> entities.
    /// </summary>
    public class CompanyRepositoryEF : ICompanyRepository
    {
        /// <summary>
        /// Instance of a Custom  <seealso cref="DbContext"/> for accesing company entities. 
        /// </summary>
        private readonly CompanyContext _db;

        /// <summary>
        /// Initializes a new instance of the <seealso cref="CompanyRepositoryEF"/> class.
        /// </summary>
        /// <param name="db">Custom  <seealso cref="DbContext"/> for accesing company entities.</param>
        public CompanyRepositoryEF(CompanyContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Create a brand new company.
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public async Task<CompanyModel> Add(CompanyModel company)
        {
            _db.Add(company);
            await _db.SaveChangesAsync();

            return company;
        }

        /// <summary>
        /// Find company object by it's id.
        /// </summary>
        /// <param name="id">Primary key of <seealso cref="CompanyModel"/> entity.</param>
        /// <returns></returns>
        public Task<CompanyModel> Find(int id)
        {
            return _db.Company.FirstOrDefaultAsync(c => c.CompanyId == id);   
        }

        /// <summary>
        /// Get the list of companies.
        /// </summary>
        /// <returns>IEnumerable of  <seealso cref="CompanyModel"/> objects. </returns>
        public async Task<IEnumerable<CompanyModel>> GetAll()
        {
            return await _db.Company.ToListAsync();
        }

        /// <summary>
        /// Remove a company from the company list.
        /// </summary>
        /// <param name="id">Primary key of <seealso cref="CompanyModel"/> entity to remove. </param>
        public async Task Remove(int id)
        {
            var companyEntity = await _db.Company.FirstOrDefaultAsync(c => c.CompanyId == id);
            _db.Company.Remove(companyEntity);
        }

        /// <summary>
        /// Update company entity.
        /// </summary>
        /// <param name="company">New company details for the specified company.</param>
        /// <returns></returns>
        public async Task<CompanyModel> Update(CompanyModel company)
        {
            _db.Update(company);
            await _db.SaveChangesAsync();

            return company;
        }
    }
}
