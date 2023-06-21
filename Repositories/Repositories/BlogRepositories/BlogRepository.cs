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
            var currentDateTime = DateTime.Now;
            return (from b in _context.Blogs
                    join u in _context.Users on b.UserId equals u.UserId
                    select new GetBlogDTO
                    {
                        BlogId = b.BlogId,
                        UserId = u.UserId,
                        FullName = u.FullName,
                        Title = b.Title,
                        BlogContent = b.BlogContent,
                        LikeCount = b.LikeCount,
                        CommentCount = b.CommentCount,
                        CreateAt = FormatDateTime(b.CreateAt, currentDateTime),
                        BlogImage = b.BlogImage,
                    }).ToList();
        }

        public bool CreateBlog(CreateBlogDTO blog)
        {
            var user = _context.Users.Find(blog.UserId);
            if (blog == null || blog.BlogContent == null || user == null) return false;
            var newBlog = _mapper.Map<Blog>(blog);
            newBlog.LikeCount = 0;
            newBlog.CommentCount = 0;
            newBlog.CreateAt = DateTime.Now;
            _context.Blogs.Add(newBlog);
            _context.SaveChanges();
            return true;
        }

        public bool LikeABlog(LikeABlogDTO action)
        {
            var user = _context.Users.Find(action.UserId);
            var blog = _context.Blogs.Find(action.BlogId);
            if (user == null || blog == null) return false;

            var existingLike = _context.Likes.Where(l => l.UserId == action.UserId && l.BlogId == action.BlogId).SingleOrDefault();
            if (existingLike != null)
            {
                _context.Likes.Remove(existingLike);
                blog.LikeCount--;
                _context.SaveChanges();
            }
            else
            {
                var like = new Like
                {
                    UserId = action.UserId,
                    BlogId = action.BlogId
                };
                blog.LikeCount++;
                _context.Likes.Add(like);
                _context.SaveChanges();
            }
            return true;
        } 
        
        public bool CommentABlog(CommentABlogDTO action)
        {
            var user = _context.Users.Find(action.UserId);
            var blog = _context.Blogs.Find(action.BlogId);
            if (user == null || blog == null || action.CommentContent == null) return false;

            var comment = _mapper.Map<Comment>(action);
            comment.CreateAt = DateTime.Now;
            _context.Comments.Add(comment);
            blog.CommentCount++;
            _context.SaveChanges();
            return true;
        }

        public bool DeleteABlog(int blogId, int userId)
        {
            var blog = _context.Blogs.Find(blogId);
            var user = _context.Users.Find(userId);
            var isYourBlog = _context.Blogs.Any(b => b.BlogId == blogId && b.UserId == userId);
            if (blog == null || user == null || !isYourBlog) return false;
            _context.Blogs.Remove(blog);
            _context.SaveChanges();
            return true;
        }

        private static string FormatDateTime(DateTime blogCreateAt, DateTime currentDateTime)
        {
            var timeDifference = currentDateTime - blogCreateAt;

            if (timeDifference.TotalDays >= 7)
            {
                // More than a week, display specific date
                return blogCreateAt.ToString("dd/MM/yyyy");
            }
            else if (timeDifference.TotalDays >= 1)
            {
                // More than a day, display number of days ago
                var daysAgo = (int)Math.Floor(timeDifference.TotalDays);
                return $"{daysAgo} days ago";
            }
            else if (timeDifference.TotalHours >= 1)
            {
                // More than an hour, display number of hours ago
                var hoursAgo = (int)Math.Floor(timeDifference.TotalHours);
                return $"{hoursAgo} hours ago";
            }
            else if (timeDifference.TotalMinutes >= 1)
            {
                // More than a minute, display number of minutes ago
                var minutesAgo = (int)Math.Floor(timeDifference.TotalMinutes);
                return $"{minutesAgo} minutes ago";
            }
            else if (timeDifference.TotalSeconds >= 1)
            {
                // More than a second, display number of seconds ago
                var secondsAgo = (int)Math.Floor(timeDifference.TotalSeconds);
                return $"{secondsAgo} seconds ago";
            }
            else
            {
                // Just now
                return "Just now";
            }
        }

        
    }
}
