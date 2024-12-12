using JWT_Learning.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JWT_Learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("AdminUser")]
        [Authorize(Roles = "AdminUser")]
        public IActionResult Admin()
        { 
            var currentuser=GetCurrentUser();
            return Ok ($"Hi {currentuser.UserName} , you are an {currentuser.Role}"); 
        }

        [HttpGet("NormalUser")]
        [Authorize(Roles = "NormalUser")]
        public IActionResult Normal()
        {
            var currentuser = GetCurrentUser();
            return Ok($"Hi {currentuser.UserName} , you are a {currentuser.Role}");
        }

        [HttpGet("AllUser")]
        [Authorize(Roles = "AdminUser,NormalUser")]
        public IActionResult All()
        {
            var currentuser = GetCurrentUser();
            return Ok($"Hi {currentuser.UserName} , you are a {currentuser.Role}");
        }



        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var UserClaims = identity.Claims;
                return new UserModel
                {
                    UserName = UserClaims.FirstOrDefault(obj => obj.Type == ClaimTypes.NameIdentifier)?.Value,
                    EmailAddress = UserClaims.FirstOrDefault(obj => obj.Type == ClaimTypes.Email)?.Value,
                    Role = UserClaims.FirstOrDefault(obj => obj.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }

    }
}
