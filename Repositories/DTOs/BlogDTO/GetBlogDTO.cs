using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.DTOs.BlogDTO
{
    public class GetBlogDTO
    {
        public int BlogId { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string BlogContent { get; set; } = null!;
    }
}
