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
        
        [HttpGet("ByAddress")]
        public IActionResult GetRestaurantById(GetAddressDTO address)
        {
            return Ok(_repo.GetResByAddress(address));
        }

    }
}
