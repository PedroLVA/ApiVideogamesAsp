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
            if(user.UserName != userDTO.UserName)
            {
                return BadRequest("Login failed");
            }
            if(new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, userDTO.Password) == PasswordVerificationResult.Failed)
            {
                return BadRequest("Login failed");
            }

            string token = CreateToken(user);

            return Ok(token);


        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:Token")!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("AppSettings:Issuer"),
                audience: configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
