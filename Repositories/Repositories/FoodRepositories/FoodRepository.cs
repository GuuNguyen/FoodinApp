using AutoMapper;
using BusinessObject.Models;
using Repositories.DTOs.FoodDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.FoodRepositories
{
    public class FoodRepository : IFoodRepository
    {
        private readonly FoodinAppManagementContext _context;
        private readonly IMapper _mapper;
        public FoodRepository(FoodinAppManagementContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GetFoodDTO> GetFoodsByRes(int id)
        {
            var list = (from f in _context.Foods
                        join r in _context.Restaurants on f.RestaurantId equals r.RestaurantId
                        join t in _context.TypeFoods on f.TypeFoodId equals t.TypeFoodId
                        where r.RestaurantId == id
                        select f).ToList();
            return _mapper.Map<List<GetFoodDTO>>(list);
        }
        public Food CreateFood(CreateFoodDTO food)
        {
            var res = _context.Restaurants.Any(f => f.RestaurantId == food.RestaurantId);
            var typeFood = _context.TypeFoods.Any(t => t.TypeFoodId == food.TypeFoodId);
            if (food.FoodName == null || food.FoodPrice == 0 || !res || !typeFood) return null;
            var newFood = _mapper.Map<Food>(food);
            _context.Foods.Add(newFood);
            _context.SaveChanges();
            return newFood;
        }
    }
}
