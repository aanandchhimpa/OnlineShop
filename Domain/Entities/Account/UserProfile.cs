using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Account
{
    public class UserProfile : BaseAuditableEntity
    {
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public string Occupation { get; set; }
        public string Company { get; set; }
        public string Bio { get; set; } // About me section
        public string Website { get; set; }
        public string SocialMediaLinks { get; set; } // JSON list of social media links
    }

}
