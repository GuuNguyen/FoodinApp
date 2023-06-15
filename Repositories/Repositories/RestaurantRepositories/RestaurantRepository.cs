using AutoMapper;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.DTOs.RestaurantDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.RestaurantRepositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly FoodinAppManagementContext _context;
        private readonly IMapper _mapper;
        public RestaurantRepository(FoodinAppManagementContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Restaurant> GetAll()
        {
            return _context.Restaurants.ToList();
        }

        public List<GetRestaurantDTO> GetResByAddress(int id)
        {
            var res = (from r in _context.Restaurants
                       join d in _context.Districts on r.DistrictId equals d.DistrictId
                       join c in _context.Cities on d.CityId equals c.CityId
                       join rt in _context.Ratings on r.RatingId equals rt.RatingId
                       where d.DistrictId == id
                       select new GetRestaurantDTO
                       {
                           RestaurantId = r.RestaurantId,
                           ResName = r.ResName,
                           Address = r.Address,
                           DistrictId = r.DistrictId,
                           PhoneNumber = r.PhoneNumber,
                           RatingId = r.RatingId,
                           CalculatedRating = CalculateRating(r.Rating),
                           Avatar = r.Avatar,
                           CoverImage = r.CoverImage
                       }).ToList();            
            return res;
        }

        public GetRestaurantDTO GetRestaurantById(int id)
        {
            var res = (from r in _context.Restaurants
                       join rt in _context.Ratings on r.RatingId equals rt.RatingId
                       where r.RestaurantId == id
                       select new GetRestaurantDTO
                       {
                           RestaurantId = r.RestaurantId,
                           ResName = r.ResName,
                           Address = r.Address,
                           DistrictId = r.DistrictId,
                           PhoneNumber = r.PhoneNumber,
                           RatingId = r.RatingId,
                           CalculatedRating = CalculateRating(r.Rating),
                           Avatar = r.Avatar,
                           CoverImage = r.CoverImage
                       }).SingleOrDefault();
            return res;
        }

        public bool CreateRestaurant(CreateResDTO res)
        {
            if(res == null) return false;
            var newRes = new Restaurant
            {
                ResName = res.ResName,
                Address = res.Address,
                DistrictId = res.DistrictId,
                PhoneNumber = res.PhoneNumber,
                RatingId = 0,
                Avatar = res.Avatar,
                CoverImage = res.CoverImage,
                Rating = new Rating()
            };
            var newRating = new Rating
            {
                OneStartCount = 0,
                TwoStartCount = 0,
                ThreeStartCount = 0,
                FourStartCount = 0,
                FiveStartCount = 0,
            };
            _context.Ratings.Add(newRating);
            newRes.RatingId = newRating.RatingId;
            newRes.Rating = newRating;
            _context.Restaurants.Add(newRes);
            _context.SaveChanges();
            return true;
        }

        public List<GetRestaurantDTO> GetFavoriteRes(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null) return null;
            var listRes = (from u in _context.Users
                          join f in _context.Favorites on u.UserId equals f.UserId
                          join r in _context.Restaurants on f.RestaurantId equals r.RestaurantId
                          join rt in _context.Ratings on r.RatingId equals rt.RatingId
                          select new GetRestaurantDTO
                          {
                              RestaurantId = r.RestaurantId,
                              ResName = r.ResName,
                              Address = r.Address,
                              DistrictId = r.DistrictId,
                              PhoneNumber = r.PhoneNumber,
                              RatingId = r.RatingId,
                              CalculatedRating = CalculateRating(r.Rating),
                              Avatar = r.Avatar,
                              CoverImage = r.CoverImage
                          }).ToList();
            
            return listRes;
        }

        public bool FavoriteARes(FavDTO dto)
        {
            var user = _context.Users.Find(dto.UserId); 
            var res = _context.Restaurants.Find(dto.RestaurantId); 
            if (user == null || res == null) return false;
            var fav = _context.Favorites.Where(f => f.UserId == dto.UserId && f.RestaurantId == dto.RestaurantId).SingleOrDefault();
            if(fav != null) _context.Favorites.Remove(fav);
            else
            {
                var newFav = _mapper.Map<Favorite>(dto);
                _context.Favorites.Add(newFav);
            }  
            _context.SaveChanges();
            return true;
        }
        private static double CalculateRating(Rating? rating)
        {
            if (rating != null)
            {
                int totalVotes = rating.OneStartCount + rating.TwoStartCount +
                                 rating.ThreeStartCount + rating.FourStartCount + 
                                 rating.FiveStartCount;

                if (totalVotes > 0)
                {
                    double averageRating = (1 * rating.OneStartCount +
                                            2 * rating.TwoStartCount +
                                            3 * rating.ThreeStartCount +
                                            4 * rating.FourStartCount +
                                            5 * rating.FiveStartCount) / totalVotes;
                    return averageRating;
                }
            }
            return 0.0;
        }

        public bool DeleteRestaurant(int id)
        {
            var res = _context.Restaurants.Find(id);
            if (res == null) return false;
            _context.Restaurants.Remove(res);
            _context.SaveChanges();
            return true;
        }
    }
}
