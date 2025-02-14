using FirstAspApp.Interfaces;
using FirstAspApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstAspApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository _genreRepository;

        public GenreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Genre>> GetGenres()
        {
            var genres = await _genreRepository.GetAllGenres();

            return Ok(genres);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> getGenre(int id)
        {
            var foundGenre = await _genreRepository.GetGenreById(id);

            if (foundGenre == null) {
                return NotFound();
            }

            return Ok(foundGenre);
        }

        [HttpPost]
        public async Task<ActionResult<Genre>> addGenre(Genre genre)
        {
            if(await _genreRepository.GetGenreByName(genre.Name) != null)
            {
                throw new Exception("Genre with that name already exists");
            }

            var addedGenre = await _genreRepository.AddGenre(genre);

            return CreatedAtAction(nameof(GetGenres), new { id = addedGenre.Id }, addedGenre);

        }

        [HttpPut]
        public async Task<IActionResult> updateGenre(Genre updatedGenre)
        {
            await _genreRepository.UpdateGenre(updatedGenre);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteGenre(int id)
        {
            var foundGenre = await _genreRepository.GetGenreById(id);

            if (foundGenre == null) {
                return NotFound();
            }

            await _genreRepository.DeleteGenre(id);
            return NoContent();
        }

    }
}
