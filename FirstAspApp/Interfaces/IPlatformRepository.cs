using FirstAspApp.Models;

namespace FirstAspApp.Interfaces
{
    public interface IPlatformRepository
    {
        Task<List<Platform>> GetAllPlatforms();
        Task<Platform?> GetPlatformById(int id);
        Task<Platform> AddPlatform(Platform platform);
        Task DeletePlatform(int id);
        Task UpdatePlatform(Platform platform);
    }
}
