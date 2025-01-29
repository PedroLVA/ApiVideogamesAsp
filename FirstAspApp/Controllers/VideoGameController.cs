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
           
        };

        [HttpGet]
        public ActionResult<List<VideoGame>> GetVideoGames()
        {
            return Ok(videoGames);
        }

        [HttpGet("{id}")]
        public ActionResult<VideoGame> GetVideoGame(int id)
        {
            var videoGame = videoGames.FirstOrDefault(vg => vg.Id == id);
            if (videoGame == null)
            {
                return NotFound();
            }
            return Ok(videoGame);
        }

        [HttpPost]
        public ActionResult<VideoGame> CreateVideoGame(VideoGame newVideoGame)
        {
            if (newVideoGame == null)
            {
                return BadRequest();
            }

            newVideoGame.Id = videoGames.Max(vg => vg.Id) + 1; //set up id manually because we dont have a database yet
            videoGames.Add(newVideoGame);
            return CreatedAtAction(nameof(GetVideoGame), new { id = newVideoGame.Id }, newVideoGame); //Didnt understand what's happening here

        }

        [HttpPut("{id}")]
        public IActionResult updateVideoGame(int id, VideoGame updatedVideoGame)    
        {
            var videoGame = videoGames.FirstOrDefault(vg => vg.Id == id);
            if (videoGame == null)
            {
                return NotFound();
            }

            videoGame.Title = updatedVideoGame.Title;
            videoGame.Platform = updatedVideoGame.Platform;
            videoGame.Developer = updatedVideoGame.Developer;
            videoGame.Publisher = updatedVideoGame.Publisher;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVideoGame(int id)
        {
            var videoGame = videoGames.FirstOrDefault(vg => vg.Id == id);
            if (videoGame == null)
            {
                return NotFound();
            }
            videoGames.Remove(videoGame);
            return NoContent();
        }

    }
}
