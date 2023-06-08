using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.DTOs.ReviewDTO
{
    public class VoteRequestModel
    {
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public bool IsHelpful { get; set; }
    }
}
