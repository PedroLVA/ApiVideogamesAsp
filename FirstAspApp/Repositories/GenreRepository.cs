using FirstAspApp.Data;
using FirstAspApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAspApp.Repositories
{
    public class GenreRepository
    {
        private readonly VideoGameDbContext _context;

        public GenreRepository(VideoGameDbContext context)
        {
            _context = context;
        }

        public async Task<Genre> AddGenre(Genre genre)
        {
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
            return genre;
        }


        public async Task DeleteGenre(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
            return;
        }


        public async Task<List<Genre>> GetAllGenres()
        {
            return await _context.Genres.ToListAsync();
        }

       
        public async Task<Genre?> getGenreById(int id)
        {
            return await _context.Genres.FindAsync(id);
        }

        public async Task updateGenre(Genre newGenre)
        {
            var genreToBeEdited = await _context.Genres.FindAsync(newGenre.Id);

            if(genreToBeEdited == null)
            {
                throw new Exception("Video game not found");
            }

            genreToBeEdited.Name = newGenre.Name;
            genreToBeEdited.ListOfVideogames = newGenre.ListOfVideogames;

            await _context.SaveChangesAsync();

            return;


        }
    }
}
