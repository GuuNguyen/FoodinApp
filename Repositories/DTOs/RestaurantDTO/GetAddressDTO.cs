using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.DTOs.RestaurantDTO
{
    public class GetAddressDTO
    {
        public int DistrictId { get; set; }
        public int CityId { get; set; }
    }
}
