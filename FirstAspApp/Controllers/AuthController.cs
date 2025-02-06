using FirstAspApp.DTOs.UserDTOs;
using FirstAspApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FirstAspApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
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
            if(user.UserName != userDTO.UserName)
            {
                return BadRequest("Login failed");
            }
            if(new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, userDTO.Password) == PasswordVerificationResult.Failed)
            {
                return BadRequest("Login failed");
            }

            string token = "success";

            return Ok(token);


        }
    }
}
