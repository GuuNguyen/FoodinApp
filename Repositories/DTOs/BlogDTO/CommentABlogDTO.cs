using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.DTOs.BlogDTO
{
    public class CommentABlogDTO
    {
        public int UserId { get; set; }
        public int BlogId { get; set; }
        public string CommentContent { get; set; } = null!;
        public DateTime CreateAt { get; set; }
    }
}
