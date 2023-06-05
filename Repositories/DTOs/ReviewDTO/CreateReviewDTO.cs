using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.DTOs.ReviewDTO
{
    public class CreateReviewDTO
    {
        public int RestaurantId { get; set; }
        public int RatingReview { get; set; }
        public string? Comment { get; set; }
        public string? Image { get; set; }
        public int UserId { get; set; }
        public int? Helpful { get; set; }
        public int? Unhelpful { get; set; }
    }
}
