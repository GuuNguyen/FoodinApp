using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.DTOs.RestaurantDTO;
using Repositories.Repositories.RestaurantRepositories;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantRepository _repo;

        public RestaurantController(IRestaurantRepository repo) => _repo = repo;

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetRestaurantById(int id)
        {
            return Ok(_repo.GetRestaurantById(id));
        }
        
        [HttpGet("ByDistrict/{id}")]
        public IActionResult GetRestaurantByDistrict(int id)
        {
            return Ok(_repo.GetResByAddress(id));
        }
        
        [HttpGet("Favorite/{userId}")]
        public IActionResult GetFavoriteRes(int userId)
        {
            var list = _repo.GetFavoriteRes(userId);
            return list != null ? Ok(list) : NotFound();
        }
        [HttpPost]
        public IActionResult CreateResraurant(CreateResDTO res)
        {
            var isSuccess = _repo.CreateRestaurant(res);
            return isSuccess ? Ok("Successful") : BadRequest("Fail");
        }
        
        [HttpPost("FavoriteARes")]
        public IActionResult AddResToFavorite(FavDTO dto)
        {
            var isSuccess = _repo.FavoriteARes(dto);
            return isSuccess ? Ok("Successful") : BadRequest("Fail");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var isSuccess = _repo.DeleteRestaurant(id);
            return isSuccess ? Ok("Successful") : BadRequest("Fail");
        }
    }
}
