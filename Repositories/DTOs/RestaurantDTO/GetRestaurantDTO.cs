using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.DTOs.RestaurantDTO
{
    public class GetRestaurantDTO
    {
        public int RestaurantId { get; set; }
        public string ResName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int DistrictId { get; set; }
        public string? PhoneNumber { get; set; }
        public int? RatingId { get; set; }
        public double CalculatedRating { get; set; }
        public string? Avatar { get; set; }
        public string? CoverImage { get; set; }
    }
}
