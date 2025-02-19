using FirstAspApp.Data;
using FirstAspApp.Interfaces;
using FirstAspApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAspApp.Repositories
{
    public class VideoGameRepository : IVideoGameRepository
    {


        private readonly VideoGameDbContext _context;

        public VideoGameRepository(VideoGameDbContext context)
        {
            _context = context;
        }

        public async Task AddGenreToVideoGame(int genreId, int videoGameId)
        {
            var foundVideoGame = await _context.VideoGames.Include(vg => vg.Genres).FirstOrDefaultAsync(vg => vg.Id == videoGameId);
            var foundGenre = await _context.Genre.FindAsync(genreId);

            if (foundGenre == null || foundVideoGame == null)
            {
                throw new Exception("Videogame or Genre not found");
            }

            if(foundVideoGame.Genres.Count() == 0)
            {
                foundVideoGame.Genres = new List<Genre>();
            }

            foundVideoGame.Genres.Add(foundGenre);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task AddPlatformToVideoGame(int videoGameId, int platformId)
        {
            var foundVideoGame = await _context.VideoGames
         .Include(vg => vg.Platforms) 
         .FirstOrDefaultAsync(vg => vg.Id == videoGameId);

            var foundPlatform = await _context.Platforms.FindAsync(platformId);

            if(foundVideoGame == null || foundPlatform == null)
            {
                throw new Exception("VideoGame or Platform not found");
            }

            if (foundVideoGame.Platforms == null) 
            {
                foundVideoGame.Platforms = new List<Platform>();
            }


            if (foundVideoGame.Platforms.Any(p => p.Id == platformId))
            {
                throw new Exception("Platform already registered in the specified VideoGame");
            }


            foundVideoGame.Platforms.Add(foundPlatform);

            await _context.SaveChangesAsync();
        }

        public async Task<VideoGame> AddVideoGame(VideoGame videoGame)
        {

            _context.VideoGames.Add(videoGame);
            await _context.SaveChangesAsync();

            return videoGame;

        }

        public async Task DeleteVideoGame(int id)
        {
            var videoGame = await _context.VideoGames.FindAsync(id);

            if (videoGame == null)
            {
                return; 
            }


            _context.VideoGames.Remove(videoGame);
            await _context.SaveChangesAsync();

            return;


        }

        public async Task<List<VideoGame>> GetAllVideoGames()
        {
            return await _context.VideoGames
                .Include(vg => vg.VideoGameDetails)
                .Include(vg => vg.Publisher)
                .Include(vg => vg.Developer)
                .Include(vg => vg.Genres)
                .Include(vg => vg.Platforms)
                .ToListAsync();
        }

        public async Task<VideoGame?> GetVideoGameById(int id)
        {
            var VideoGame = await _context.VideoGames
               .Include(vg => vg.VideoGameDetails)
               .Include(vg => vg.Publisher)
               .Include(vg => vg.Developer)
               .Include(vg => vg.Genres)
               .Include(vg => vg.Platforms)
               .FirstOrDefaultAsync(vg => vg.Id == id);

            return VideoGame;
        }

        public async Task<List<VideoGame>> GetVideoGamesByGenre(string genreName)
        {
            var listOfVideoGames = await _context.VideoGames.Where(vg => vg.Genres.Any(g => g.Name == genreName)).Include(vg => vg.Genres).ToListAsync();


            return listOfVideoGames;
        }

        public async Task UpdateVideoGame(VideoGame videoGame)
        {
            var VideoGameToUpdate = await _context.VideoGames.FindAsync(videoGame.Id);
            if(VideoGameToUpdate == null)
            {
                throw new Exception("VideoGame not found");
            }

            VideoGameToUpdate.Title = videoGame.Title;
            VideoGameToUpdate.Platforms = videoGame.Platforms;
            VideoGameToUpdate.DeveloperId = videoGame.DeveloperId;
            VideoGameToUpdate.PublisherId = videoGame.PublisherId;

            await _context.SaveChangesAsync();

            return;
        }

    }
}
