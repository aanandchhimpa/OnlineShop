using Domain.Common;

namespace Domain.Entities.Products
{
    public class ProductVariant : BaseAuditableEntity
    {
        public int ProductId { get; set; }
        public ProductDetail Product { get; set; }

        public int ProductAttributeValueId { get; set; }
        public ProductAttributeValue ProductAttributeValue { get; set; }

        public decimal? AdditionalPrice { get; set; } // If a variant affects the price
        public int StockQuantity { get; set; } // Stock per variant
    }


}
