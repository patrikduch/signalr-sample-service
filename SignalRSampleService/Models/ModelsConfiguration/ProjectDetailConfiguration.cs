using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SignalRSampleService.Models.ModelsConfiguration
{
    /// <summary>
    /// Mapping and restriction policy for ProjectDetail model.
    /// </summary>
    public class ProjectDetailConfiguration : IEntityTypeConfiguration<ProjectDetail>
    {
        /// <summary>
        /// Mapping functionality for project detail model.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<ProjectDetail> builder)
        {

            builder.ToTable("projectdetail");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")
                .IsRequired(true);

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .IsRequired(true);

            builder.Property(p => p.AuthorName)
                .HasColumnName("authorname")
                .IsRequired(true);
        }
    }
}
