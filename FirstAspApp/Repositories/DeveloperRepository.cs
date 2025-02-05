using FirstAspApp.Data;
using FirstAspApp.Interfaces;
using FirstAspApp.Models;

namespace FirstAspApp.Repositories
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly VideoGameDbContext _context;

        public DeveloperRepository(VideoGameDbContext context)
        {
            _context = context;
        }


        public Task<Developer> AddDeveloper(Developer developer)
        {

            throw new NotImplementedException();
        }

        public Task DeleteDeveloper(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Developer>> GetAllDevelopers()
        {
            throw new NotImplementedException();
        }

        public Task<Developer?> GetDeveloperById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Developer> GetDeveloperByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDeveloper(Developer developer)
        {
            throw new NotImplementedException();
        }
    }
}
