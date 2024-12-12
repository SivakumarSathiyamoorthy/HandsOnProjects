using JWT_Learning.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace JWT_Learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLogin user)
        {
            var UserDetails=AutheticateUser(user);
            if(UserDetails == null) { return NotFound(); }
            else { var token = GenerateToken(UserDetails);  return Ok (token); }

        }

        private string GenerateToken(UserModel user) 
        {
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var Credentials = new SigningCredentials(SecurityKey,SecurityAlgorithms.HmacSha256);

            var claim = new Claim[]
            {
               new Claim(ClaimTypes.NameIdentifier,user.UserName),
               new Claim(ClaimTypes.Email,user.EmailAddress),
               new Claim(ClaimTypes.Role,user.Role)

            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"],claim,expires:DateTime.Now.AddMinutes(60),signingCredentials:Credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);  
                
                }

        private UserModel AutheticateUser(UserLogin user) 
        {
            var CurrentUser = UserConstants.Users.FirstOrDefault(obj => obj.UserName.ToLower() == user.UserName.ToLower() && obj.Password == user.Password);
            if (CurrentUser != null) { return CurrentUser; }
            else return null;
        }



    }
}
