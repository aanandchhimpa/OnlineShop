using Domain.Common;
using Domain.Entities.Products;

namespace Domain.Entities.DynamicFilters
{
    public class Filter : BaseAuditableEntity
    {
        public string Name { get; set; } // e.g., "Color", "Size", "Taste"

        public virtual ICollection<FilterValue> FilterValues { get; set; } = new List<FilterValue>();
    }


    public class FilterValue : BaseAuditableEntity
    {
        public int FilterId { get; set; }  // Foreign Key to Filter
        public virtual Filter Filter { get; set; }

        public string Value { get; set; } // e.g., "Red", "Large", "Sweet"

        public virtual ICollection<ProductFilter> ProductFilters { get; set; } = new List<ProductFilter>();
    }

    public class ProductFilter : BaseAuditableEntity
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int FilterId { get; set; }
        public virtual Filter Filter { get; set; }

        public int FilterValueId { get; set; }
        public virtual FilterValue FilterValue { get; set; }
    }

}
