using BusinessObject.Models;
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

        [HttpGet]
        public IActionResult GetAllUser()
        {
            return Ok(_repo.GetAll());
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
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var isSuccess = _repo.Delete(id);
            return isSuccess ? Ok("Successful") : BadRequest("Fail");
        }

        [HttpPut("ChangeSubcriptionStatus/{userId}")]
        public IActionResult ChangeSubcriptionStatus(int userId)
        {
            var isSuccess = _repo.ChangeSubscriptionStatus(userId);
            return isSuccess ? Ok("Successful") : BadRequest("Fail");
        }
    }
}
