using AutoMapper;
using BusinessObject.Models;
using Repositories.DTOs.BlogDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly FoodinAppManagementContext _context;
        private readonly IMapper _mapper;
        public BlogRepository(FoodinAppManagementContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetBlogDTO> GetAll()
        {
            return (from b in _context.Blogs
                    join u in _context.Users on b.UserId equals u.UserId
                    select new GetBlogDTO
                    {
                        BlogId = b.BlogId,
                        UserId = u.UserId,
                        FullName = u.FullName,
                        Title = b.Title,
                        BlogContent = b.BlogContent,
                    }).ToList();
        }

        public bool CreateBlog(CreateBlogDTO blog)
        {
            var user = _context.Users.Find(blog.UserId);
            if (blog == null || user == null) return false;           
            var newBlog = _mapper.Map<Blog>(blog);
            _context.Blogs.Add(newBlog);
            _context.SaveChanges();
            return true;
        }
    }
}
