using Microsoft.EntityFrameworkCore;
using SignalRSampleService.Models;
using SignalRSampleService.Models.ModelsConfiguration;

namespace SignalRSampleService.Contexts
{
    /// <summary>
    /// Custom <seealso cref="DbContext"/> for managing project details.
    /// </summary>
    public class ProjectDetailContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <seealso cref="ProjectDetailContext"/> class.
        /// </summary>
        /// <param name="options"></param>
        public ProjectDetailContext(DbContextOptions<ProjectDetailContext> options) : base(options){}

        /// <summary>
        /// Configuration setup for <seealso cref="ProjectDetailContext"/>.
        /// </summary>
        /// <param name="builder"><seealso cref="ModelBuilder"/> instance that is used for additional Model configuration.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Addd the Postgres Extension for UUID generation
            builder.HasPostgresExtension("uuid-ossp");

            // Rules for the ProjectDetail entity
            builder.ApplyConfiguration(new ProjectDetailConfiguration());
        }

        /// <summary>
        /// Dbset for accessing <seealso cref="ProjectDetailModel"/> objects.
        /// </summary>
        public DbSet<ProjectDetailModel> ProjectDetail { get; set; }
    }
}
