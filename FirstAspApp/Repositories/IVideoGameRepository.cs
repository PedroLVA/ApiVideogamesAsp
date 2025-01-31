using FirstAspApp.Models;

namespace FirstAspApp.Repositories
{
    public interface IVideoGameRepository
    {
        List<VideoGame> GetAllVideoGames();

        VideoGame GetVideoGameById(int id);

        void AddVideoGame(VideoGame videoGame);

        void UpdateVideoGame(VideoGame videoGame);

        void DeleteVideoGame(int id);


    }
}
