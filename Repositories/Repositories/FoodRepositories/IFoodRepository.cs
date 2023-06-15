using BusinessObject.Models;
using Repositories.DTOs.FoodDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.FoodRepositories
{
    public interface IFoodRepository
    {
        List<GetFoodDTO> GetFoodsByRes(int id);
        Food CreateFood(CreateFoodDTO food);
    }
}
