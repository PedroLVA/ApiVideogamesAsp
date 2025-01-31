using FirstAspApp.Data;
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


        public Task AddVideoGame(VideoGame videoGame)
        {
            throw new NotImplementedException();
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

        public Task<VideoGame> GetVideoGameById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateVideoGame(VideoGame videoGame)
        {
            throw new NotImplementedException();
        }
    }
}
