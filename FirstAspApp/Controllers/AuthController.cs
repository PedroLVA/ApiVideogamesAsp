
using FirstAspApp.DTOs.Token;
using FirstAspApp.DTOs.UserDTOs;
using FirstAspApp.Models;
using FirstAspApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirstAspApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
     

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDTO userDTO)
        {
           var user = await authService.RegisterAsync(userDTO);

            if(user is null)
            {
                return BadRequest("User already exists");
            }

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDto>> Login(UserDTO userDTO)
        {
            var result = await authService.LoginAsync(userDTO);
            if (result is null)
            {
                return Unauthorized("Invalid credentials");
            }

            return Ok(result);


            }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenResponseDto>> RefreshToken(RefreshTokenRequestDTO request)
        {
            var result = await authService.RefreshTokensAsync(request);
            if (result is null || result.AccessToken is null || result.RefreshToken is null)
            {
                return Unauthorized("Invalid Refresh token");
            }
            return Ok(result);
        }


        [Authorize]
        [HttpGet("authenticated")]
        public IActionResult AuthenticatedEndpoint()
        {
            return Ok("You are authenticated");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin-only")]
        public IActionResult AdminOnlyEndpoint()
        {
            return Ok("You are authenticated");
        }

        [Authorize(Roles = "User")]
        [HttpGet("user-only")]
        public IActionResult UserOnlyEndpoint()
        {
            return Ok("You are authenticated");
        }


    }
}
