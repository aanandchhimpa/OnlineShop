using Domain.Entities.DynamicFilters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Filters_confi
{

    public class FilterConfiguration : IEntityTypeConfiguration<Filter>
    {
        public void Configure(EntityTypeBuilder<Filter> builder)
        {
            builder.ToTable("Filters");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(100);

            // One-to-Many: Filter → FilterValues
            builder.HasMany(f => f.FilterValues)
                .WithOne(fv => fv.Filter)
                .HasForeignKey(fv => fv.FilterId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
