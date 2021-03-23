using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SignalRSampleService.Models.ModelsConfiguration
{
    /// <summary>
    /// Mapping and restriction policy for Company model.
    /// </summary>
    public class CompanyModelConfiguration : IEntityTypeConfiguration<CompanyModel>
    {
        /// <summary>
        /// Mapping functionality for Company model.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<CompanyModel> builder)
        {
            builder.ToTable("company");

            builder.Property(c => c.Id)
               .HasColumnName("id")
               .HasColumnType("uuid")
               .HasDefaultValueSql("uuid_generate_v4()")
               .IsRequired(true);

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Address)
               .HasColumnName("address")
               .IsRequired(true);

            builder.Property(c => c.Name)
                .HasColumnName("name")
                .IsRequired(true);

            builder.Property(c => c.City)
                 .HasColumnName("city")
                 .IsRequired(true);


            builder.Property(c => c.State)
                .HasColumnName("state")
                .IsRequired(true);


            builder.Property(c => c.PostalCode)
                .HasColumnName("postalcode")
                .IsRequired(true);

        }
    
    }
}
