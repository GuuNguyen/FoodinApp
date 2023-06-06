using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Repositories.ImageRepositories;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;

        public ImageController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        [HttpGet("{RestaurantID}")]
        public IActionResult GetImagesByRestaurantID(int RestaurantID)
        {
            return Ok(_imageRepository.GetImagesByRestaurantID(RestaurantID));
        }
    }
}
