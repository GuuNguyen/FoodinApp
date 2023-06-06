using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.CityRepositories
{
    public interface ICityRepository
    {
        List<City> GetCities();
    }
}
