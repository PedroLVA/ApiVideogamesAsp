using FirstAspApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstAspApp.Repositories
{
    public interface IVideoGameRepository
    {
        Task<List<VideoGame>> GetAllVideoGames();

        Task<VideoGame?> GetVideoGameById(int id);

        Task<VideoGame> AddVideoGame(VideoGame videoGame);

        Task UpdateVideoGame(VideoGame videoGame);

        Task DeleteVideoGame(int id);


    }
}
