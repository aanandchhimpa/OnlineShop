using Domain.Common;

namespace Domain.Entities.Products
{
    public class ProductImage : BaseAuditableEntity
    {
        public int ProductId { get; set; }
        public ProductDetail Product { get; set; }

        public string ImageUrl { get; set; }
        public bool IsPrimary { get; set; } // For the main product image
    }


}
