using BusinessObject.Models;
using Repositories.DTOs.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.UserRepositories
{
    public interface IUserRepository
    {
        User Login(LoginDTO user);
        List<User> GetAll();
        bool Register(CreateUserDTO user);
        bool Delete(int id);
    }
}
