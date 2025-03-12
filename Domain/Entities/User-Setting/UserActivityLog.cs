using Domain.Common;
using Domain.Entities.Account;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.User_Setting
{
    public class UserActivityLog : BaseAuditableEntity
    {
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public string Action { get; set; } // Example: "Logged In", "Changed Password"

        public DateTime Timestamp { get; set; } // When the action occurred

        public string IPAddress { get; set; } // User's IP address

        public string DeviceInfo { get; set; } // Device details (optional)
    }

}
