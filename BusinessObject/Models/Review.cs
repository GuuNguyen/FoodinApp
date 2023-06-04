using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public int RestaurantId { get; set; }
        public DateTime DateReview { get; set; }
        public int RatingReview { get; set; }
        public string? Comment { get; set; }
        public string? Image { get; set; }
        public int UserId { get; set; }
        public int? Helpful { get; set; }
        public int? Unhelpful { get; set; }

        public virtual Restaurant Restaurant { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
