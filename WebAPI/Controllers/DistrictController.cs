using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Repositories.DistrictRepositories;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictRepository _districtRepository;

        public DistrictController(IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        }

        [HttpGet("{CityID}")]
        public IActionResult GetDistrictsByCityID(int CityID)
        {
            return Ok(_districtRepository.GetDistrictsByCityID(CityID));
        }
    }
}
