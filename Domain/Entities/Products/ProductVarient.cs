using Domain.Common;

namespace Domain.Entities.Products
{
    public class ProductVariant : BaseAuditableEntity
    {
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public decimal? AdditionalPrice { get; set; }
        public int StockQuantity { get; set; }

        public virtual ICollection<ProductVariantAttribute> VariantAttributes { get; set; } = new List<ProductVariantAttribute>();
    }

    public class ProductVariantAttribute : BaseAuditableEntity
    {
        public Guid ProductVariantId { get; set; }
        public virtual ProductVariant ProductVariant { get; set; }

        public Guid ProductAttributeId { get; set; }
        public virtual ProductAttribute ProductAttribute { get; set; }

        public Guid ProductAttributeValueId { get; set; }
        public virtual ProductAttributeValue ProductAttributeValue { get; set; }
    }



}
