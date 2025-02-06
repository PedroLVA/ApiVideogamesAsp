using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FirstAspApp.DTOs.UserDTOs;
using FirstAspApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FirstAspApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IConfiguration configuration) : ControllerBase
    {
        public static User user = new User();

        [HttpPost("register")]
        public ActionResult<User> Register(UserDTO userDTO)
        {
            var hashedPassword = new PasswordHasher<User>().HashPassword(user, userDTO.Password);

            user.UserName = userDTO.UserName;
            user.Email = userDTO.Email;
            user.PasswordHash = hashedPassword;

            return Ok(user);
        }

        [HttpPost("login")]
        public ActionResult<string> Login(UserDTO userDTO)
        {
            


        }

       
    }
}
