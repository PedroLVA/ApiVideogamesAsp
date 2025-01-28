using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAspApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {

        private static readonly List<VideoGame> videoGames = new()
        {
            new VideoGame { Id = 1, Title = "The Legend of Zelda: Breath of the Wild", Platform = "Nintendo Switch", Developer = "Nintendo", Publisher = "Nintendo" },
            new VideoGame { Id = 2, Title = "God of War", Platform = "PlayStation 4", Developer = "Santa Monica Studio", Publisher = "Sony Interactive Entertainment" },
            new VideoGame { Id = 3, Title = "Cyberpunk 2077", Platform = "PC, PlayStation, Xbox", Developer = "CD Projekt Red", Publisher = "CD Projekt" },
            new VideoGame { Id = 4, Title = "Halo Infinite", Platform = "Xbox, PC", Developer = "343 Industries", Publisher = "Xbox Game Studios" },
            new VideoGame { Id = 5, Title = "Red Dead Redemption 2", Platform = "PlayStation, Xbox, PC", Developer = "Rockstar Games", Publisher = "Rockstar Games" }
        };


        [HttpGet]
        public ActionResult<List<VideoGame>> GetVideoGames()
        {
            return Ok(videoGames);
        }
    }
}
