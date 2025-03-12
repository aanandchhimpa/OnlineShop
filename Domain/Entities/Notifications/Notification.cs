using Domain.Common;
using Domain.Entities.Account;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Notifications
{
    public class Notification : BaseAuditableEntity
    {
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public string Title { get; set; } // Notification title (e.g., "Order Shipped")

        public string Message { get; set; } // Detailed notification message

        public bool IsRead { get; set; } // To track if the user has seen it

        public DateTime SentOn { get; set; } // When the notification was created

        public NotificationType Type { get; set; } // Enum to classify notifications

        public NotificationChannel Channel { get; set; } // Enum: In-App, Email, SMS, Push

        public int? ReferenceId { get; set; } // Can be OrderId, ProductId, etc.

        public string ReferenceType { get; set; } // Stores type like "Order", "Product"
    }

    public enum NotificationType
    {
        OrderUpdate, Promotion, AccountActivity, Wishlist, SystemAlert, Review
    }

    public enum NotificationChannel
    {
        InApp, Email, SMS, PushNotification
    }


}
