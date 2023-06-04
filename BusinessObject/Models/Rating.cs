using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Rating
    {
        public Rating()
        {
            Restaurants = new HashSet<Restaurant>();
        }

        public int RatingId { get; set; }
        public int OneStartCount { get; set; }
        public int TwoStartCount { get; set; }
        public int ThreeStartCount { get; set; }
        public int FourStartCount { get; set; }
        public int FiveStartCount { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}
