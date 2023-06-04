using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Image
    {
        public int ImageId { get; set; }
        public int RestaurantId { get; set; }
        public string Image1 { get; set; } = null!;

        public virtual Restaurant Restaurant { get; set; } = null!;
    }
}
