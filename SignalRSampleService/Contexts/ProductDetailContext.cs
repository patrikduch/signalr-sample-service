using Microsoft.EntityFrameworkCore;
using SignalRSampleService.Models;
using SignalRSampleService.Models.ModelsConfiguration;

namespace SignalRSampleService.Contexts
{
    /// <summary>
    /// DB context for managing project detail details.
    /// </summary>
    public class ProjectDetailContext : DbContext
    {
        public ProjectDetailContext(DbContextOptions<ProjectDetailContext> options) : base(options)
        {

        }

        /// <summary>
        /// Configuration setup for ProjectDetail DB context.
        /// </summary>
        /// <param name="builder">Modelbuilder instance that is used for additional Model configuration.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Addd the Postgres Extension for UUID generation
            builder.HasPostgresExtension("uuid-ossp");

            // Rules for the ProjectDetail entity
            builder.ApplyConfiguration(new ProjectDetailConfiguration());
        }

        public DbSet<ProjectDetailModel> ProjectDetail { get; set; }
    }
}
