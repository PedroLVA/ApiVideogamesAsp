using FirstAspApp.Data;
using FirstAspApp.DTOs.UserDTOs;
using FirstAspApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FirstAspApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly VideoGameDbContext _context;
        private readonly IConfiguration  _configuration;

        public AuthService(VideoGameDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public Task<string?> LoginAsync(UserDTO request)
        {
            throw new NotImplementedException();
        }


        public async Task<User?> RegisterAsync(UserDTO request)
        {

            if(await _context.Users.AnyAsync(u => u.UserName == request.UserName))
            {
                return null;
            }

            var user = new User();

            var hashedPassword = new PasswordHasher<User>().HashPassword(user, request.Password);

            user.UserName = request.UserName;
            user.Email = request.Email;
            user.PasswordHash = hashedPassword;

             _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
