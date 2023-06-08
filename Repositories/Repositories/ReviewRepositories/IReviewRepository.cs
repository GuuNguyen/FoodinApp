using BusinessObject.Models;
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
        bool CreateAReview(CreateReviewDTO review);
        List<Restaurant> GetTopRestaurantTrending();
        void VoteAReview(VoteRequestModel model);
    }
}
