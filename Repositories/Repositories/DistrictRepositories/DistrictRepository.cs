using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.DistrictRepositories
{
    public class DistrictRepository : IDistrictRepository
    {
        private readonly FoodinAppManagementContext _context;

        public DistrictRepository(FoodinAppManagementContext context)
        {
            _context = context;
        }
        List<District> IDistrictRepository.GetDistrictsByCityID(int cityID)
        {
            var districts = _context.Districts.Where(d => d.CityId == cityID).ToList();

            var sortedDistricts = districts.OrderBy(d => d.DistrictId == 21 ? 9 : d.DistrictId)
                                  .ToList();

            return sortedDistricts;
        }
    }
}
