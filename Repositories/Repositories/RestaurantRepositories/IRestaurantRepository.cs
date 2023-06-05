using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.RestaurantRepositories
{
    public interface IRestaurantRepository
    {
        Restaurant GetRestaurantById(int id);
    }
}
