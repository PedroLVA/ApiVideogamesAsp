using FirstAspApp.Data;
using FirstAspApp.Interfaces;
using FirstAspApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAspApp.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly VideoGameDbContext _context;

        public GenreRepository(VideoGameDbContext context)
        {
            _context = context;
        }

        public async Task<Genre> AddGenre(Genre genre)
        {
            _context.Genre.Add(genre);
            await _context.SaveChangesAsync();
            return genre;
        }


        public async Task DeleteGenre(int id)
        {
            var genre = await _context.Genre.FindAsync(id);
            if (genre == null)
            {
                throw new Exception("Genre not found");
            }
            _context.Genre.Remove(genre);
            await _context.SaveChangesAsync();
            return;
        }


        public async Task<List<Genre>> GetAllGenres()
        {
            return await _context.Genre.ToListAsync();
        }

       
        public async Task<Genre?> GetGenreById(int id)
        {
            return await _context.Genre.FindAsync(id);
        }


        public async Task<Genre?> GetGenreByName(string name)
        {
            return await _context.Genre.FirstOrDefaultAsync(g => g.Name == name);
        }


        public async Task UpdateGenre(Genre newGenre)
        {
            var genreToBeEdited = await _context.Genre.FindAsync(newGenre.Id);

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
