using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.DTOs.FoodDTO
{
    public class CreateFoodDTO
    {
        public int TypeFoodId { get; set; }
        public int RestaurantId { get; set; }
        public string FoodName { get; set; } = null!;
        public double FoodPrice { get; set; }
        public string? FoodImage { get; set; }     
    }
}
