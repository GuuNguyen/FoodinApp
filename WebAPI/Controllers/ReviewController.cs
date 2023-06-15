using BusinessObject.Models;
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

        [HttpGet("{restaurantId}")]
        public IActionResult GetAllReviewByRestaurant(int restaurantId)
        {
            return Ok(_repo.GetReviews(restaurantId));
        }

        [HttpPost]
        public IActionResult CreateAReview(CreateReviewDTO review)
        {
            var isSuccess = _repo.CreateAReview(review);
            return isSuccess ? Ok(isSuccess) : BadRequest();
        }

        [HttpGet("TrendingRestaurant/{districtID}")]
        public IActionResult GetTrendingRestaurant(int districtID)
        {
            return Ok(_repo.GetTopRestaurantTrendingByDistrictId(districtID));
        }

        [HttpPost("Vote")]
        public IActionResult VoteAReview(VoteRequestModel model)
        {
            _repo.VoteAReview(model);
            return Ok();
        }

        [HttpDelete("{reviewId}/User/{userId}")]
        public IActionResult Delete(int reviewId, int userId)
        {
            var isSuccess = _repo.RemoveAReview(reviewId, userId);
            return isSuccess ? Ok("Successful") : BadRequest("Fail");
        }
    }
}
