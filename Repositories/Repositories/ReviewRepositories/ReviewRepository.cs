using AutoMapper;
using BusinessObject.Models;
using Repositories.DTOs.ReviewDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.ReviewRepositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly FoodinAppManagementContext _context;
        private readonly IMapper _mapper;

        public ReviewRepository(FoodinAppManagementContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CreateAReview(CreateReviewDTO review)
        {
            if(review == null) return false;
            var newReview = _mapper.Map<Review>(review);
            newReview.DateReview = DateTime.Now;
            _context.Reviews.Add(newReview);
            _context.SaveChanges();
            return true;
        }
    }
}
