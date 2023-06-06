using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.DTOs.ReviewDTO;
using Repositories.Repositories.ReviewRepositories;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _repo;
        public ReviewController(IReviewRepository repo) => _repo = repo;

        [HttpPost]
        public IActionResult CreateAReview(CreateReviewDTO review)
        {
            var isSuccess = _repo.CreateAReview(review);
            return isSuccess ? Ok(isSuccess) : BadRequest();
        }

        [HttpGet("TrendingRestaurant")]
        public IActionResult GetTrendingRestaurant()
        {
            return Ok(_repo.GetTopRestaurantTrending());
        }
    }
}
