using AutoMapper;
using BusinessObject.Models;
using Repositories.DTOs.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FoodinAppManagementContext _context;
        private readonly IMapper _mapper;

        public UserRepository(FoodinAppManagementContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User Login(LoginDTO user)
        {
            var thisUser = _context.Users.Where(u => u.UserName == user.UserName && u.Password == user.Password).FirstOrDefault();
            if (thisUser != null)
            {
                return thisUser;
            }
            return null;
        }

        public bool Register(CreateUserDTO user)
        {
            if (user.Email == null || user.FullName == null || user.PhoneNumber == null ||
                user.UserName == null || user.Password == null) return false;

            var isExisted = _context.Users.Where(u => u.UserName == user.UserName || u.Email == user.Email).Any();
            if (isExisted) return false;

            var newUser = _mapper.Map<User>(user);
            newUser.SubscriptionStatus = false;
            newUser.Point = 0;
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return false;
            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }

        public bool ChangeSubscriptionStatus(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null) return false;
            if (user.SubscriptionStatus == false)
            {
                user.SubscriptionStatus = true;
                _context.SaveChanges();
                return true;
            }
            user.SubscriptionStatus = false;
            _context.SaveChanges();
            return true;
        }
    }
}
