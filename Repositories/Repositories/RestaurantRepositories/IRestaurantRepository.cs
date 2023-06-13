using BusinessObject.Models;
using Repositories.DTOs.RestaurantDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.RestaurantRepositories
{
    public interface IRestaurantRepository
    {
        List<Restaurant> GetAll();
        Restaurant GetRestaurantById(int id);
        List<Restaurant> GetResByAddress(int id);
        bool CreateRestaurant(CreateResDTO res);
    }
}
