using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.DTOs.FoodDTO;
using Repositories.Repositories.FoodRepositories;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodRepository _repo;
        public FoodController(IFoodRepository repo) => _repo = repo;

        [HttpGet("{restaurantId}")]
        public IActionResult GetFoodByRes(int restaurantId)
        {
            return Ok(_repo.GetFoodsByRes(restaurantId));
        }

        [HttpPost]
        public IActionResult CreateAFood(CreateFoodDTO food)
        {
            var isCreated = _repo.CreateFood(food);
            return isCreated != null ? Ok(isCreated) : BadRequest();
        }
    }
}
