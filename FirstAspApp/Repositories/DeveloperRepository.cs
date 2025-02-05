using FirstAspApp.Data;
using FirstAspApp.Interfaces;
using FirstAspApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAspApp.Repositories
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly VideoGameDbContext _context;

        public DeveloperRepository(VideoGameDbContext context)
        {
            _context = context;
        }


        public async Task<Developer> AddDeveloper(Developer developer)
        {
            _context.Developer.Add(developer);
            await _context.SaveChangesAsync();

          return developer;
        }

        public Task DeleteDeveloper(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Developer>> GetAllDevelopers()
        {
            var developers = await _context.Developer.ToListAsync();

            return developers;
        }

        public Task<Developer?> GetDeveloperById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Developer> GetDeveloperByName(string name)
        {
            var foundDeveloper = await _context.Developer.FirstOrDefaultAsync(d => d.Name == name);
            if(foundDeveloper == null)
            {
                throw new Exception("Developer not found");
            }

            return foundDeveloper;
        }

        public Task UpdateDeveloper(Developer developer)
        {
            throw new NotImplementedException();
        }
    }
}
