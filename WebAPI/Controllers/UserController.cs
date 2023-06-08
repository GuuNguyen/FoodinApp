using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.DTOs.UserDTO;
using Repositories.Repositories.UserRepositories;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _repo;

        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginDTO user)
        {
            return Ok(_repo.Login(user));   
        }
        [HttpPost("Register")]
        public IActionResult Register(CreateUserDTO user)
        {
            var isSuccess = _repo.Register(user);
            return isSuccess ? Ok("Successful created!") : BadRequest("Fail created!");
        }
    }
}
