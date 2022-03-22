using Microsoft.AspNetCore.Identity;
using OnlineShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.IServices
{
    public interface IUserService
    {
        Task<User> Register(string username, string email, string password, string mobile);
        Task<SignInResult> LogIn(string username, string password);
        Task LogOut();
    }
}
