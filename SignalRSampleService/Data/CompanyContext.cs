using Microsoft.EntityFrameworkCore;
using SignalRSampleService.Models;
using SignalRSampleService.Models.ModelsConfiguration;

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
        /// Configuration setup for <seealso cref="CompanyContext"/>.
        /// </summary>
        /// <param name="builder"><seealso cref="ModelBuilder"/> instance that is used for additional Model configuration.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Addd the Postgres Extension for UUID generation
            builder.HasPostgresExtension("uuid-ossp");

            // Rules for the ProjectDetail entity
            builder.ApplyConfiguration(new CompanyModelConfiguration());
        }

        /// <summary>
        /// Dbset for accessing <seealso cref="CompanyModel"/> objects.
        /// </summary>
        public DbSet<CompanyModel> Company { get; set; }
    }
}
