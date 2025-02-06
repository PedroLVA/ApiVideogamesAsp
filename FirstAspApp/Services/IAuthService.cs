using FirstAspApp.DTOs.UserDTOs;
using FirstAspApp.Models;
using System.Threading.Tasks;

namespace FirstAspApp.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDTO request);
        Task<string?> LoginAsync(UserDTO request);
    }
}
