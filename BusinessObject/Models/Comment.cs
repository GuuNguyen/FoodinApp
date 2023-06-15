using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int BlogId { get; set; }
        public string CommentContent { get; set; } = null!;
        public DateTime CreateAt { get; set; }

        public virtual Blog Blog { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
