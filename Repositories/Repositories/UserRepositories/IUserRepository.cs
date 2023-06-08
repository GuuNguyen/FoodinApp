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
        bool Register(CreateUserDTO user);
    }
}
