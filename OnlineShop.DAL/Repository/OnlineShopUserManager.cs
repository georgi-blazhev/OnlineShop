using Microsoft.AspNetCore.Identity;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.Repository
{
    public class OnlineShopUserManager : IUserManager
    {
        private readonly UserManager<User> _userManager;

        public OnlineShopUserManager(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> AddToRoleAsync(User user, string role)
        {
            return await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<User> CreateUserAsync(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            
            return await _userManager.FindByNameAsync(user.UserName);
        }

        public Task DeleteUserAsync(User user)
        {
            return _userManager.DeleteAsync(user);
        }

        public Task<User> FindByIdAsync(string userId)
        {
            return _userManager.FindByIdAsync(userId);
        }

        public async Task<User> FindByNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public Task<List<User>> GetAllAsync()
        {
            return Task.FromResult(_userManager.Users.ToList());
        }

        public Task<User> GetCurrentUser(ClaimsPrincipal principal)
        {
            return _userManager.GetUserAsync(principal);
        }

        public async Task<List<string>> GetUserRolesAsync(User user)
        {
            return  (await _userManager.GetRolesAsync(user)).ToList();
        }

        public Task UpdateUserAsync(User user, string currentPassword, string newPassword)
        {
            return _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        }
    }
}
