using BusinessObject.Models;
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

        [HttpPost("LikeOrUnlike")]
        public IActionResult LikeABlog(LikeABlogDTO blog)
        {
            var isLiked = _repo.LikeABlog(blog);
            return isLiked ? Ok("Successful") : BadRequest("Fail");
        }

        [HttpPost("Comment")]
        public IActionResult CommentABlog(CommentABlogDTO comment)
        {
            var isComment = _repo.CommentABlog(comment);
            return isComment ? Ok("Successful") : BadRequest("Fail");
        }

        [HttpDelete("{blogId}/User/{userId}")]
        public IActionResult Delete(int blogId, int userId)
        {
            var isDeleted = _repo.DeleteABlog(blogId, userId);
            return isDeleted ? Ok("Successful") : BadRequest("Fail");
        }
    }
}
