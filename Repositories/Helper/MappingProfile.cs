﻿using AutoMapper;
using BusinessObject.Models;
using Repositories.DTOs.BlogDTO;
using Repositories.DTOs.FoodDTO;
using Repositories.DTOs.RestaurantDTO;
using Repositories.DTOs.ReviewDTO;
using Repositories.DTOs.UserDTO;
using Repositories.DTOs.VoucherDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Repositories.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Review, CreateReviewDTO>().ReverseMap();
            CreateMap<Review, GetReviewDTO>().ReverseMap();
            CreateMap<User, CreateUserDTO>().ReverseMap();
            CreateMap<Blog, CreateBlogDTO>().ReverseMap();
            CreateMap<Favorite, FavDTO>().ReverseMap();
            CreateMap<Restaurant, GetRestaurantDTO>().ReverseMap();
            CreateMap<Comment, CommentABlogDTO>().ReverseMap();
            CreateMap<Food, GetFoodDTO>().ReverseMap();
            CreateMap<Food, CreateFoodDTO>().ReverseMap();
            CreateMap<Vote, GetVoteDTO>().ReverseMap();
            CreateMap<Voucher, CreateVoucherDTO>().ReverseMap();
        }
    }
}
