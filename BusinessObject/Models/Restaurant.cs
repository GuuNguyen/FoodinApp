using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            Foods = new HashSet<Food>();
            Images = new HashSet<Image>();
            Reviews = new HashSet<Review>();
        }

        public int RestaurantId { get; set; }
        public string ResName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int DistrictId { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public int RatingId { get; set; }
        public string Avatar { get; set; } = null!;

        public virtual District District { get; set; } = null!;
        public virtual Rating Rating { get; set; } = null!;
        public virtual ICollection<Food> Foods { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
