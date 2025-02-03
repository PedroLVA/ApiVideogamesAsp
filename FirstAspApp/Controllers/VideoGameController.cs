using FirstAspApp.Data;
using FirstAspApp.DTOs.VideoGameDTOs;
using FirstAspApp.Models;
using FirstAspApp.Repositories;
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

            return CreatedAtAction(nameof(GetVideoGame), new { id = newVideoGame.Id }, newVideoGame); //Didnt understand what's happening here

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
