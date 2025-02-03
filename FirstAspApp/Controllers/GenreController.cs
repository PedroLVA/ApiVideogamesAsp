using FirstAspApp.Models;
using FirstAspApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAspApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository _genreRepository; //doesnt exist yet

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
        




    }
}
