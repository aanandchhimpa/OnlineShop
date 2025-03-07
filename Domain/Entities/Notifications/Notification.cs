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
        public string Title { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; } // To track if the user has seen it
        public DateTime SentOn { get; set; }
    }

}
