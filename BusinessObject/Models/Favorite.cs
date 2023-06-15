using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Favorite
    {
        public int FavoriteId { get; set; }
        public int UserId { get; set; }
        public int RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
