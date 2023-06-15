using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class User
    {
        public User()
        {
            Blogs = new HashSet<Blog>();
            Comments = new HashSet<Comment>();
            Favorites = new HashSet<Favorite>();
            Likes = new HashSet<Like>();
            Reviews = new HashSet<Review>();
            Votes = new HashSet<Vote>();
        }

        public int UserId { get; set; }
        public string FullName { get; set; } = null!;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool SubscriptionStatus { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
    }
}
