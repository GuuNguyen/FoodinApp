using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Blog
    {
        public int BlogId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; } = null!;
        public string BlogContent { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
