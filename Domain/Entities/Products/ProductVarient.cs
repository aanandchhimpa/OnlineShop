using Domain.Common;

namespace Domain.Entities.Products
{
    public class ProductVariant : BaseAuditableEntity
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public decimal? AdditionalPrice { get; set; }
        public int StockQuantity { get; set; }

        public virtual ICollection<ProductVariantAttribute> VariantAttributes { get; set; } = new List<ProductVariantAttribute>();
    }

    public class ProductVariantAttribute : BaseAuditableEntity
    {
        public int ProductVariantId { get; set; }
        public virtual ProductVariant ProductVariant { get; set; }

        public int ProductAttributeId { get; set; }
        public virtual ProductAttribute ProductAttribute { get; set; }

        public int ProductAttributeValueId { get; set; }
        public virtual ProductAttributeValue ProductAttributeValue { get; set; }
    }



}
