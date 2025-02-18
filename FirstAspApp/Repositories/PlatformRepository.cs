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

        public async Task DeletePlatform(int id)
        {
            var foundPlatform = await _context.Platforms.FindAsync(id);

            if(foundPlatform == null)
            {
                throw new Exception("Platform not found");
            }

            _context.Platforms.Remove(foundPlatform);

            await _context.SaveChangesAsync();
        }

        public Task<List<Platform>> GetAllPlatforms()
        {
            throw new NotImplementedException();
        }

        public async Task<Platform?> GetPlatformById(int id)
        {
            var foundPlatform = await _context.Platforms.FindAsync(id);
            if (foundPlatform == null)
            {
                return null;
            }
            return foundPlatform;
        }

        public Task UpdatedePlatform(Platform platform)
        {
            throw new NotImplementedException();
        }
    }
}
