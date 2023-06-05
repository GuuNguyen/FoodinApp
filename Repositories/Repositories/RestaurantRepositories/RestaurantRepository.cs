using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
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
        public Restaurant GetRestaurantById(int id)
        {
            return _context.Restaurants.Include(r => r.District).Include(r => r.Rating).Where(r => r.RestaurantId == id).SingleOrDefault();
        }
    }
}
