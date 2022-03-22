using Microsoft.AspNetCore.Identity;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.Repository
{
    public class OnlineShopSignInManager : ISignInManager
    {
        private readonly SignInManager<User> _signInManager;

        public OnlineShopSignInManager(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            return _signInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);
        }

        public Task SignOutAsync()
        {
            return _signInManager.SignOutAsync();
        }
    }
}
