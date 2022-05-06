using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Store.DataAccessor.Data;
using Store.DataAccessor.Entities;
using Store.Models.Requests;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _db;

        public AuthenticateController(IConfiguration config, SignInManager<User> signInManager, UserManager<User> userManager, ApplicationDbContext db)
        {
            _config = config;
            _signInManager = signInManager;
            _userManager = userManager;
            _db = db;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            IActionResult result = Unauthorized();
            var user = await AuthenticatedUser(request);
            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                result = Ok(new { token = tokenString });
            }
            return result;
        }

        private object GenerateJSONWebToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claimsIdentity = new[]
            {
                new Claim("Name", user.Email),
                new Claim("TestClaim","Any thing you want")
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims: claimsIdentity,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<User> AuthenticatedUser(UserLoginRequest request)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);
            if (result.Succeeded)
            {
                var userInfo = await _userManager.FindByEmailAsync(request.Email);
                return userInfo;
            }
            return null;
        }
    }
}
