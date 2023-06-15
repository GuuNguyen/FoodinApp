using BusinessObject.Models;
using Repositories.DTOs.RestaurantDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.RestaurantRepositories
{
    public interface IRestaurantRepository
    {
        List<Restaurant> GetAll();
        GetRestaurantDTO GetRestaurantById(int id);
        List<GetRestaurantDTO> GetFavoriteRes(int userId);
        List<GetRestaurantDTO> GetResByAddress(int id);
        bool CreateRestaurant(CreateResDTO res);
        bool FavoriteARes(FavDTO dto);
        bool DeleteRestaurant(int id);
    }
}
