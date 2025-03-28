using Domain.Entities.DynamicFilters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Filters_confi
{

    public class FilterValueConfiguration : IEntityTypeConfiguration<FilterValue>
    {
        public void Configure(EntityTypeBuilder<FilterValue> builder)
        {
            builder.ToTable("FilterValues");

            builder.HasKey(fv => fv.Id);

            builder.Property(fv => fv.Value)
                .IsRequired()
                .HasMaxLength(100);

            // Many-to-One: FilterValue → Filter
            builder.HasOne(fv => fv.Filter)
                .WithMany(f => f.FilterValues)
                .HasForeignKey(fv => fv.FilterId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many: FilterValue → ProductFilters
            builder.HasMany(fv => fv.ProductFilters)
                .WithOne(pf => pf.FilterValue)
                .HasForeignKey(pf => pf.FilterValueId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
