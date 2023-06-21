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
            var cities = _context.Cities.ToList();

            var sortedCities = cities.OrderBy(c => c.CityName == "Ho Chi Minh" ? 1 : (c.CityName == "Da Nang City" ? 2 : (c.CityName == "Ha Noi" ? 3 : 4)))
                                    .ThenBy(c => c.CityName)
                                    .ToList();

            return sortedCities;
        }
    }
}
