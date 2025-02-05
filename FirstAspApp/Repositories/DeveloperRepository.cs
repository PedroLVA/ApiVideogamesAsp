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

        public async Task DeleteDeveloper(int id)
        {
            var developerToBeDeleted = await _context.Developer.FirstOrDefaultAsync(d => d.Id == id);

            if (developerToBeDeleted == null)
            {
                throw new Exception("Developer not found");
            }
            _context.Developer.Remove(developerToBeDeleted);

            await _context.SaveChangesAsync();

            return;

        }

        public async Task<List<Developer>> GetAllDevelopers()
        {
            var developers = await _context.Developer.ToListAsync();

            return developers;
        }

        public Task<Developer?> GetDeveloperById(int id)
        {
            var foundDeveloper = _context.Developer.FirstOrDefaultAsync(d => d.Id == id);

            return foundDeveloper;
        }

        public async Task<Developer> GetDeveloperByName(string name)
        {
            var foundDeveloper = await _context.Developer.FirstOrDefaultAsync(d => d.Name == name);
            if (foundDeveloper == null)
            {
                throw new Exception("Developer not found");
            }

            return foundDeveloper;
        }

        public async Task UpdateDeveloper(Developer developer)
        {
            var developerToBeUpdated = await _context.Developer.FirstOrDefaultAsync(d => d.Id == developer.Id);
            if (developerToBeUpdated == null)
            {
                throw new Exception("Developer not found");
            }
            developerToBeUpdated.Name = developer.Name;

            await _context.SaveChangesAsync();

            return;
        }
    }
}
