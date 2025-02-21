using FirstAspApp.DTOs.VideoGameDTOs;
using FirstAspApp.Models;

namespace FirstAspApp.Interfaces
{
    public interface IVideoGameRepository
    {
        Task<List<VideoGame>> GetAllVideoGames();

        Task<VideoGame?> GetVideoGameById(int id);

        Task<VideoGame> AddVideoGame(VideoGamePostDTO videoGameDTO);

        Task UpdateVideoGame(VideoGame videoGame);

        Task DeleteVideoGame(int id);

        Task AddPlatformToVideoGame(int videoGameId, int platformId);

        Task<List<VideoGame>> GetVideoGamesByGenre(string genreName);

        Task AddGenreToVideoGame(int genreId, int videoGameId);


    }
}
