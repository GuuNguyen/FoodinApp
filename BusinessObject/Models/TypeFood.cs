using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class TypeFood
    {
        public TypeFood()
        {
            Foods = new HashSet<Food>();
        }

        public int TypeFoodId { get; set; }
        public string TypeFoodName { get; set; } = null!;

        public virtual ICollection<Food> Foods { get; set; }
    }
}
