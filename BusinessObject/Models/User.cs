using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class User
    {
        public User()
        {
            Reviews = new HashSet<Review>();
        }

        public int UserId { get; set; }
        public string FullName { get; set; } = null!;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool SubscriptionStatus { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
