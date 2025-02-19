
using FirstAspApp.DTOs.VideoGameDTOs;
using FirstAspApp.Interfaces;
using FirstAspApp.Models;
using Microsoft.AspNetCore.Mvc;


namespace FirstAspApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {


        private readonly IVideoGameRepository _videoGameRepository;

        public VideoGameController(IVideoGameRepository videoGameRepository)
        {
            _videoGameRepository = videoGameRepository;
        }

        [HttpPost("{videoGameId}/platforms/{platformId}")]
        public async Task<IActionResult> AddPlatformToVideoGame(int videoGameId, int platformId)
        {
            await _videoGameRepository.AddPlatformToVideoGame(videoGameId, platformId);
            return NoContent();
        }

        [HttpPost("{videoGameId}/genre/{genreId}")]
        public async Task<ActionResult> AddGenreToVideoGame(int genreId, int videoGameId)
        {
            await _videoGameRepository.AddGenreToVideoGame(genreId, videoGameId);

            return NoContent();

        }

        [HttpGet("genre/{genreName}")]
        public async Task<ActionResult<List<VideoGame>>> GetVideoGamesByGenre(string genreName)
        {
            var videoGames = await _videoGameRepository.GetVideoGamesByGenre(genreName);
            if(videoGames == null)
            {
                return NotFound("No VideoGames found for this genre");
            }

            var videoGameDTOs = videoGames.Select(vg => new VideoGameGetResponseDTO(vg)).ToList();
            return Ok(videoGameDTOs);
        }

        [HttpGet]
        public async Task<ActionResult<List<VideoGameGetResponseDTO>>> GetVideoGames()
        {
            var videoGames = await _videoGameRepository.GetAllVideoGames();

            var videoGameDTOs = videoGames.Select(vg => new VideoGameGetResponseDTO(vg)).ToList();

            return Ok(videoGameDTOs);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<VideoGame>> GetVideoGame(int id)
        {
            var videoGame = await _videoGameRepository.GetVideoGameById(id);

            if (videoGame == null)
            {
                return NotFound();
            }

            VideoGameGetResponseDTO videoGameDTO = new VideoGameGetResponseDTO(videoGame);

            return Ok(videoGameDTO);
        }

        [HttpPost]
        public async Task<ActionResult<VideoGame>> CreateVideoGame(VideoGame newVideoGame)
        {
           var videoGame = await _videoGameRepository.AddVideoGame(newVideoGame);

            return CreatedAtAction(nameof(GetVideoGame), new { id = newVideoGame.Id }, newVideoGame); 

        }

        [HttpPut]
        public async Task<IActionResult> updateVideoGame(VideoGame updatedVideoGame)    
        {
            await _videoGameRepository.UpdateVideoGame(updatedVideoGame);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideoGame(int id)
        {

            var foundVideoGame = await _videoGameRepository.GetVideoGameById(id);

            if(foundVideoGame == null)
            {
                return NotFound();
            }

            await _videoGameRepository.DeleteVideoGame(id);

            return NoContent();
        }

    }
}
