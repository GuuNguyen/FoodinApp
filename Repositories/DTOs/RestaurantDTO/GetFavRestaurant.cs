using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.DTOs.RestaurantDTO
{
    public class GetFavRestaurant
    {
        public int RestaurantId { get; set; }
        public string? ResName { get; set; } 
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public double CalculatedRating { get; set; }
        public string? Avatar { get; set; }
    }
}
