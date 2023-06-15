using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Blog
    {
        public Blog()
        {
            Comments = new HashSet<Comment>();
            Likes = new HashSet<Like>();
        }

        public int BlogId { get; set; }
        public int UserId { get; set; }
        public string? Title { get; set; }
        public string BlogContent { get; set; } = null!;
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        public DateTime CreateAt { get; set; }
        public string? BlogImage { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
    }
}
