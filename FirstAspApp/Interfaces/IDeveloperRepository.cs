using FirstAspApp.Models;

namespace FirstAspApp.Interfaces
{
    public interface IDeveloperRepository
    {
        Task<List<Developer>> GetAllDevelopers();
        
        Task<Developer?> GetDeveloperById(int id);

        Task<Developer> AddDeveloper(Developer developer);

        Task UpdateDeveloper(Developer developer);

        Task DeleteDeveloper(int id);

        Task<Developer> GetDeveloperByName(string name);
    }
}
