using Microsoft.EntityFrameworkCore;
using SignalRSampleService.Models;

namespace SignalRSampleService.Data
{
    /// <summary>
    /// Custom <seealso cref="DbContext"/> for managing companies data.
    /// </summary>
    public class CompanyContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <seealso cref="CompanyContext"/> class.
        /// </summary>
        /// <param name="options"></param>
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options) { }

        /// <summary>
        /// Dbset for accessing <seealso cref="CompanyModel"/> objects.
        /// </summary>
        public DbSet<CompanyModel> Company { get; set; }
    }
}
