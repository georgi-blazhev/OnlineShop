using Microsoft.AspNetCore.Mvc;
using OnlineShop.BLL.IServices;
using OnlineShop.DTO.Users.Requests;

namespace OnlineShop.WEB.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser user)
        {
            var userResult = await _userService.Register(user.UserName, user.Email, user.Password, user.Mobile);

            return Ok(userResult);
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> LogIn(string username, string password)
        {
            var result = await _userService.LogIn(username, password);

            if (result.Succeeded)
            {
                return Ok(result);
            }

            return Unauthorized();
        }

        [Route("logout")]
        [HttpPost]
        public async Task LogOut()
        {
            await _userService.LogOut();
        }
    }
}
