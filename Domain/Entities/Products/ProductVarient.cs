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

   



}
