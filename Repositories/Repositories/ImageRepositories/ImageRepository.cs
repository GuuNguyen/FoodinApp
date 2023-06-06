using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.ImageRepositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly FoodinAppManagementContext _context;

        public ImageRepository(FoodinAppManagementContext context)
        {
            _context = context;
        }
        public List<Image> GetImagesByRestaurantID(int RestaurantID)
        {
            return _context.Images.Where(i => i.RestaurantId == RestaurantID).ToList();
        }
    }
}
