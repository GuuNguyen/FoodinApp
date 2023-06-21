using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.CityRepositories
{
    public class CityRepository : ICityRepository
    {
        private readonly FoodinAppManagementContext _context;

        public CityRepository(FoodinAppManagementContext context) => _context = context;
        public List<City> GetCities()
        {
            return _context.Cities.OrderBy(c => c.CityName == "Ho Chi Minh" ? 0 : 1).ToList();
        }
    }
}
