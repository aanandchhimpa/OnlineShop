using Domain.Common;
using Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User_Setting
{
    public class UserSettings : BaseAuditableEntity
    {
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public bool AllowEmailNotifications { get; set; } // Enable/disable email notifications

        public bool AllowSmsNotifications { get; set; } // Enable/disable SMS notifications

        public bool AllowPushNotifications { get; set; } // Enable/disable push notifications

        public bool AllowOrderStatusUpdates { get; set; } // Notify about order updates

        public bool AllowPromotionalEmails { get; set; } // Notify about offers & deals

        public bool AllowWishlistAlerts { get; set; } // Notify when wishlist item price drops

        public bool AllowReviewAlerts { get; set; } // Notify when someone replies to a review

        public string PreferredLanguage { get; set; } // Preferred language (e.g., "en", "hi")

        public bool DarkModeEnabled { get; set; } // UI preference for dark mode
    }

}
