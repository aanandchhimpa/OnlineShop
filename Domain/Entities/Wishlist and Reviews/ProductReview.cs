using Domain.Common;
using Domain.Entities.Account;
using Domain.Entities.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Wishlist_and_Reviews
{
    public class ProductReview : BaseAuditableEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public int Rating { get; set; } // e.g., 1-5 stars
        public string Comment { get; set; }
    }

}
