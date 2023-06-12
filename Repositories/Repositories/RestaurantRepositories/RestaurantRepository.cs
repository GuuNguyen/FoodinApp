using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.DTOs.RestaurantDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.RestaurantRepositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly FoodinAppManagementContext _context;
        public RestaurantRepository(FoodinAppManagementContext context) => _context = context;

        public List<Restaurant> GetAll()
        {
            return _context.Restaurants.ToList();
        }

        public List<Restaurant> GetResByAddress(int id)
        {
            var res = (from r in _context.Restaurants
                       join d in _context.Districts on r.DistrictId equals d.DistrictId
                       join c in _context.Cities on d.CityId equals c.CityId
                       where d.DistrictId == id
                       select r).ToList();
            return res;
        }

        public Restaurant GetRestaurantById(int id)
        {
            return _context.Restaurants.Where(r => r.RestaurantId == id).SingleOrDefault();
        }
    }
}
