using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.DTOs.BlogDTO
{
    public class CreateBlogDTO
    {
        public int UserId { get; set; }
        public string? Title { get; set; }
        public string BlogContent { get; set; } = null!;
        public string? BlogImage { get; set; }
    }
}
