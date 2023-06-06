using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.ImageRepositories
{
    public interface IImageRepository
    {
        List<Image> GetImagesByRestaurantID(int RestaurantID);
    }
}
