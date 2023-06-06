using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.DistrictRepositories
{
    public interface IDistrictRepository
    {
        List<District> GetDistrictsByCityID(int cityID);
    }
}
