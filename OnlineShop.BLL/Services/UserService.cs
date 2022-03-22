using Microsoft.AspNetCore.Identity;
using OnlineShop.BLL.IServices;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OnlineShop.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserManager _userManager;
        private readonly ISignInManager _signInManager;

        public UserService(IUserManager userManager, ISignInManager signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public Task<SignInResult> LogIn(string username, string password)
        {
            return _signInManager.PasswordSignInAsync(username, password, true, false);
        }

        public Task LogOut()
        {
            return _signInManager.SignOutAsync();
        }

        public async Task<User> Register(string username, string email, string password, string mobile)
        {
            const string role = "RegularUser";

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                User newUser = new User
                {
                    UserName = username,
                    Email = email,
                    NormalizedUserName = username.ToUpper(),
                    NormalizedEmail = email.ToUpper(),
                    EmailConfirmed = false,
                    PhoneNumber = mobile
                };

                User newlyCreatedUser = await _userManager.CreateUserAsync(newUser, password);
                await _userManager.AddToRoleAsync(newlyCreatedUser, role);

                scope.Complete();
                scope.Dispose();
            }

            return await _userManager.FindByNameAsync(username);
        }
    }
}
