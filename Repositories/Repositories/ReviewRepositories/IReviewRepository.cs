using BusinessObject.Models;
using Repositories.DTOs.RestaurantDTO;
using Repositories.DTOs.ReviewDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.ReviewRepositories
{
    public interface IReviewRepository
    {
        List<GetReviewDTO> GetReviews(int resId);
        bool CreateAReview(CreateReviewDTO review);
        List<GetRestaurantDTO> GetTopRestaurantTrendingByDistrictId(int districtId);
        void VoteAReview(VoteRequestModel model);
        List<GetVoteDTO> GetVotedByUser(int userId);
        bool RemoveAReview(int reviewId, int userId);
    }
}
