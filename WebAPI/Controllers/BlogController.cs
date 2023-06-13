using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.DTOs.BlogDTO;
using Repositories.Repositories.BlogRepositories;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepository _repo;
        public BlogController(IBlogRepository repo) => _repo = repo;

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repo.GetAll());
        }
        [HttpPost]
        public IActionResult CreateBlog(CreateBlogDTO blog)
        {
            var isSuccess = _repo.CreateBlog(blog);
            return isSuccess ? Ok("Successful") : BadRequest("Fail");
        }
    }
}
