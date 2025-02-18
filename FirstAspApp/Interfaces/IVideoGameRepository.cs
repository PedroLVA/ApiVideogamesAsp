using FirstAspApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstAspApp.Interfaces
{
    public interface IVideoGameRepository
    {
        Task<List<VideoGame>> GetAllVideoGames();

        Task<VideoGame?> GetVideoGameById(int id);

        Task<VideoGame> AddVideoGame(VideoGame videoGame);

        Task UpdateVideoGame(VideoGame videoGame);

        Task DeleteVideoGame(int id);

        Task AddPlatformToVideoGame(int videoGameId, int platformId);


    }
}
