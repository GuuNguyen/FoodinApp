using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Food
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; } = null!;
        public double FoodPrice { get; set; }
        public int TypeFoodId { get; set; }
        public int RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; } = null!;
        public virtual TypeFood TypeFood { get; set; } = null!;
    }
}
