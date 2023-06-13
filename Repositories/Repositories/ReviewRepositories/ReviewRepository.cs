using AutoMapper;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
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
            var newReview = _mapper.Map<Review>(review);
            var res = _context.Restaurants.Find(review.RestaurantId);
            var rating = _context.Ratings.Where(r => r.RatingId == res.RatingId).SingleOrDefault();
            if (review == null || res == null || rating == null) return false;
            if(review.RatingReview == 1){ rating.OneStartCount++;}
            else if(review.RatingReview == 2) {  rating.TwoStartCount++; }
            else if(review.RatingReview == 3) {  rating.ThreeStartCount++; }
            else if(review.RatingReview == 4) {  rating.FourStartCount++; }
            else if(review.RatingReview == 5) {  rating.FiveStartCount++; }
            _context.Ratings.Update(rating);
            newReview.DateReview = DateTime.Now;
            newReview.Helpful = 0;
            newReview.Unhelpful = 0;
            _context.Reviews.Add(newReview);
            _context.SaveChanges();
            return true;
        }

        public List<Restaurant> GetTopRestaurantTrendingByDistrictId(int districtId)
        {
            var top5Restaurants = _context.Reviews
                .Where(r => r.Restaurant.DistrictId == districtId) // Lọc các review theo districtId
                .GroupBy(r => r.RestaurantId) // Nhóm các review theo RestaurantId
                .OrderByDescending(g => g.Count()) // Sắp xếp theo số lượng review giảm dần
                .Take(5) // Lấy ra 5 nhóm đầu tiên
                .Select(g => g.Key) // Chọn RestaurantId từ mỗi nhóm
                .Join(_context.Restaurants, r => r, restaurant => restaurant.RestaurantId, (r, restaurant) => restaurant) // Kết hợp với bảng Restaurants để lấy thông tin nhà hàng
                .ToList();

            return top5Restaurants;
        }


        public void VoteAReview(VoteRequestModel model)
        {
            var existingVote = _context.Votes.FirstOrDefault(v => v.ReviewId == model.ReviewId && v.UserId == model.UserId);
            if (existingVote != null)
            {
                _context.Votes.Remove(existingVote);

                var review = _context.Reviews.FirstOrDefault(r => r.ReviewId == model.ReviewId);
                if (review != null)
                {
                    if (model.IsHelpful)
                    {
                        review.Helpful--;
                    }
                    else
                    {
                        review.Unhelpful--;
                    }
                }
                _context.SaveChanges();
            }
            else
            {
                var vote = new Vote
                {
                    ReviewId = model.ReviewId,
                    UserId = model.UserId,
                    IsHelpful = model.IsHelpful,
                };
                _context.Votes.Add(vote);
                var review = _context.Reviews.FirstOrDefault(r => r.ReviewId == model.ReviewId);
                if (review != null)
                {
                    if (model.IsHelpful)
                    {
                        review.Helpful++;
                    }
                    else
                    {
                        review.Unhelpful++;
                    }
                }
                _context.SaveChanges();
            }
        }
    }
}
