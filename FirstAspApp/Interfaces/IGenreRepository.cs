using FirstAspApp.Models;

namespace FirstAspApp.Interfaces
{
    public interface IGenreRepository
    {
        Task<List<Genre>> GetAllGenres();

        Task<Genre?> GetGenreById(int id);

        Task<Genre> AddGenre(Genre videogenre);

        Task UpdateGenre(Genre genre);

        Task DeleteGenre(int id);

        Task<Genre?> GetGenreByName(string name);
    }
}
