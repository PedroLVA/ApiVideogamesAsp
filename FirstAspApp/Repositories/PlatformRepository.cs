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

        Task<Platform> IPlatformRepository.AddPlatform(Platform platform)
        {
            throw new NotImplementedException();
        }

        Task IPlatformRepository.DeletePlatform(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<Platform>> IPlatformRepository.GetAllPlatforms()
        {
            throw new NotImplementedException();
        }

        Task<Platform?> IPlatformRepository.GetPlatformById(int id)
        {
            throw new NotImplementedException();
        }

        Task IPlatformRepository.UpdatedePlatform(Platform platform)
        {
            throw new NotImplementedException();
        }
    }
}
