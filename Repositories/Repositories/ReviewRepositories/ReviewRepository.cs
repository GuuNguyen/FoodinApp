using AutoMapper;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.DTOs.RestaurantDTO;
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
        public List<GetReviewDTO> GetReviews(int resId)
        {
            var currentDateTime = DateTime.Now;
            var reviewList = (from rv in _context.Reviews
                              join re in _context.Restaurants on rv.RestaurantId equals re.RestaurantId
                              join u in _context.Users on rv.UserId equals u.UserId
                              where re.RestaurantId == resId
                              select new GetReviewDTO
                              {
                                  ReviewId = rv.ReviewId,
                                  RestaurantId = rv.RestaurantId,
                                  UserId = rv.UserId,
                                  Title = rv.Title,
                                  FullName = u.FullName,
                                  DateReview = FormatDateTime(rv.DateReview, currentDateTime),
                                  RatingReview = rv.RatingReview,
                                  Comment = rv.Comment,
                                  Image = rv.Image,
                                  Helpful = rv.Helpful,
                                  Unhelpful = rv.Unhelpful
                              }).ToList();
            var sortedList = reviewList.OrderByDescending(r => r.Helpful).ToList();
            return sortedList;
        }
        public bool CreateAReview(CreateReviewDTO review)
        {
            var newReview = _mapper.Map<Review>(review);
            var res = _context.Restaurants.Find(review.RestaurantId);
            var rating = _context.Ratings.Where(r => r.RatingId == res.RatingId).SingleOrDefault();
            if (review == null || res == null || rating == null) return false;
            if (review.RatingReview == 1) { rating.OneStartCount++; }
            else if (review.RatingReview == 2) { rating.TwoStartCount++; }
            else if (review.RatingReview == 3) { rating.ThreeStartCount++; }
            else if (review.RatingReview == 4) { rating.FourStartCount++; }
            else if (review.RatingReview == 5) { rating.FiveStartCount++; }
            _context.Ratings.Update(rating);
            newReview.DateReview = DateTime.Now;
            newReview.Helpful = 0;
            newReview.Unhelpful = 0;
            _context.Reviews.Add(newReview);
            _context.SaveChanges();
            return true;
        }

        public List<GetRestaurantDTO> GetTopRestaurantTrendingByDistrictId(int districtId)
        {
            var top5Restaurants = _context.Reviews
                .Where(r => r.Restaurant.DistrictId == districtId) // Lọc các review theo districtId
                .GroupBy(r => r.RestaurantId) // Nhóm các review theo RestaurantId
                .OrderByDescending(g => g.Count()) // Sắp xếp theo số lượng review giảm dần
                .Take(5) // Lấy ra 5 nhóm đầu tiên
                .Select(g => g.Key) // Chọn RestaurantId từ mỗi nhóm
                .Join(_context.Restaurants, r => r, restaurant => restaurant.RestaurantId, (r, restaurant) => restaurant) // Kết hợp với bảng Restaurants để lấy thông tin nhà hàng
                .ToList();

            var newList = _mapper.Map<List<GetRestaurantDTO>>(top5Restaurants);
            foreach (var restaurant in newList)
            {
                restaurant.CalculatedRating = 0.0;
            }
            return newList;
        }

        public void VoteAReview(VoteRequestModel model)
        {
            var existingVote = _context.Votes.FirstOrDefault(v => v.ReviewId == model.ReviewId && v.UserId == model.UserId);
            var user = _context.Users.Find(model.UserId);
            if (existingVote != null)
            {
                _context.Votes.Remove(existingVote);

                var review = _context.Reviews.FirstOrDefault(r => r.ReviewId == model.ReviewId);
                if (review != null)
                {
                    review.Helpful--;
                }
                _context.SaveChanges();
            }
            else
            {
                var vote = new Vote
                {
                    ReviewId = model.ReviewId,
                    UserId = model.UserId,
                };
                _context.Votes.Add(vote);
                var review = _context.Reviews.FirstOrDefault(r => r.ReviewId == model.ReviewId);
                if (review != null)
                {
                    review.Helpful++;
                    if (review.Helpful % 100 == 0)
                    {
                        user.Point += (review.Helpful / 100) * 1000;
                        _context.SaveChanges();
                    }
                }
                _context.SaveChanges();
            }          
        }
        public bool RemoveAReview(int reviewId, int userId)
        {
            var review = _context.Reviews.Find(reviewId);
            var isYourReview = _context.Reviews.Any(r => r.ReviewId == reviewId && r.UserId == userId);
            if (review == null || !isYourReview) return false;
            _context.Reviews.Remove(review);
            _context.SaveChanges();
            return true;
        }

        public List<GetVoteDTO> GetVotedByUser(int userId)
        {
            var list = _context.Votes.Where(v => v.UserId == userId).ToList();
            return _mapper.Map<List<GetVoteDTO>>(list);
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
