using FirstAspApp.Data;
using FirstAspApp.Models;
using Microsoft.AspNetCore.Mvc;
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


        public async Task<VideoGame> AddVideoGame(VideoGame videoGame)
        {

            _context.VideoGames.Add(videoGame);
            await _context.SaveChangesAsync();

            return videoGame;

        }

        public Task DeleteVideoGame(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<VideoGame>> GetAllVideoGames()
        {
            return await _context.VideoGames
                .Include(vg => vg.VideoGameDetails)
                .Include(vg => vg.Publisher)
                .Include(vg => vg.Developer)
                .Include(vg => vg.Genres)
                .ToListAsync();
        }

        public async Task<VideoGame?> GetVideoGameById(int id)
        {
            var VideoGame = await _context.VideoGames
               .Include(vg => vg.VideoGameDetails)
               .Include(vg => vg.Publisher)
               .Include(vg => vg.Developer)
               .Include(vg => vg.Genres)
               .FirstOrDefaultAsync(vg => vg.Id == id);

            return VideoGame;
        }

        public async Task UpdateVideoGame(VideoGame videoGame)
        {
            var VideoGameToUpdate = await _context.VideoGames.FindAsync(videoGame.Id);
            if(VideoGameToUpdate == null)
            {
                throw new Exception("Character not found");
            }

            VideoGameToUpdate.Title = videoGame.Title;
            VideoGameToUpdate.Platform = videoGame.Platform;
            VideoGameToUpdate.DeveloperId = videoGame.DeveloperId;
            VideoGameToUpdate.PublisherId = videoGame.PublisherId;

            await _context.SaveChangesAsync();

            return;
        }

    }
}
