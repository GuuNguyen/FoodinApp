using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class District
    {
        public District()
        {
            Restaurants = new HashSet<Restaurant>();
        }

        public int DistrictId { get; set; }
        public string DistrictName { get; set; } = null!;
        public int CityId { get; set; }

        public virtual City City { get; set; } = null!;
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}
