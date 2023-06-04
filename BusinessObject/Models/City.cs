using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class City
    {
        public City()
        {
            Districts = new HashSet<District>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; } = null!;

        public virtual ICollection<District> Districts { get; set; }
    }
}
