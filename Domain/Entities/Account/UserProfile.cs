using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Account
{
    public class UserProfile : BaseAuditableEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public string Occupation { get; set; }
        public string Company { get; set; }
        public string Bio { get; set; } // About me section
        public string Website { get; set; }
        public string SocialMediaLinks { get; set; } // JSON list of social media links
    }

}
