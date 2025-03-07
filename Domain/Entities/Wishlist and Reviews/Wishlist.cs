using Domain.Common;
using Domain.Entities.Account;
using Domain.Entities.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Wishlist_and_Reviews
{
    public class Wishlist : BaseAuditableEntity
    {
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public ICollection<WishlistItem> Items { get; set; }
    }

    public class WishlistItem : BaseAuditableEntity
    {
        public int ProductId { get; set; }
        public ProductDetail Product { get; set; }
        public int WishlistId { get; set; }
        public Wishlist Wishlist { get; set; }
    }

}
