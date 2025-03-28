using Domain.Entities.DynamicFilters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Filters_confi
{
    public class ProductFilterConfiguration : IEntityTypeConfiguration<ProductFilter>
    {
        public void Configure(EntityTypeBuilder<ProductFilter> builder)
        {
            builder.ToTable("ProductFilters");

            builder.HasKey(pf => pf.Id);

            // Many-to-One: ProductFilter → Product
            builder.HasOne(pf => pf.Product)
                .WithMany(p => p.ProductFilters)
                .HasForeignKey(pf => pf.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // Many-to-One: ProductFilter → Filter
            builder.HasOne(pf => pf.Filter)
                .WithMany()
                .HasForeignKey(pf => pf.FilterId)
                .OnDelete(DeleteBehavior.Cascade);

            // Many-to-One: ProductFilter → FilterValue
            builder.HasOne(pf => pf.FilterValue)
                .WithMany(fv => fv.ProductFilters)
                .HasForeignKey(pf => pf.FilterValueId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
