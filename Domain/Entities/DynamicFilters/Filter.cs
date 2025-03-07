using Domain.Common;
using Domain.Entities.Products;

namespace Domain.Entities.DynamicFilters
{
    public class Filter : BaseAuditableEntity
    {
        public string FilterType { get; set; } // e.g., "Size", "Color", "Price"
        public string Value { get; set; } // e.g., "Small", "Red", "500-1000"
    }

    public class ProductFilter : BaseAuditableEntity
    {
        public int ProductId { get; set; }
        public ProductDetail Product { get; set; }
        public int FilterId { get; set; }
        public Filter Filter { get; set; }
    }

}
