using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Repositories.RestaurantRepositories;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantRepository _repo;

        public RestaurantController(IRestaurantRepository repo) => _repo = repo;

        [HttpGet("{id}")]
        public IActionResult GetRestaurantById(int id)
        {
            return Ok(_repo.GetRestaurantById(id));
        }
    }
}
