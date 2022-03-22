using Microsoft.AspNetCore.Identity;
using OnlineShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.IRepository
{
    public interface IUserManager 
    {
        Task<User> FindByIdAsync(string userId);
        Task<User> FindByNameAsync(string userName);
        Task<List<User>> GetAllAsync();
        Task<User> GetCurrentUser(ClaimsPrincipal principal);
        Task<User> CreateUserAsync(User user, string password);
        Task UpdateUserAsync(User user, string currentPassword, string newPassword);
        Task DeleteUserAsync(User user);
        Task<IdentityResult> AddToRoleAsync(User user, string role);
        Task<List<string>> GetUserRolesAsync(User user);
    }
}
