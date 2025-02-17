using FirstAspApp.Data;
using FirstAspApp.Interfaces;
using FirstAspApp.Models;

namespace FirstAspApp.Repositories
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly VideoGameDbContext _context;

        public PlatformRepository(VideoGameDbContext context)
        {
            _context = context;
        }

        public async Task<Platform> AddPlatform(Platform platform)
        {
            _context.Platforms.Add(platform);
            await _context.SaveChangesAsync();
            return platform;
        }

        public Task DeletePlatform(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Platform>> GetAllPlatforms()
        {
            throw new NotImplementedException();
        }

        public Task<Platform?> GetPlatformById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatedePlatform(Platform platform)
        {
            throw new NotImplementedException();
        }
    }
}
