using FirstAspApp.Interfaces;
using FirstAspApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAspApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepository platformRepository;

        public PlatformController(IPlatformRepository platformRepository)
        {
            this.platformRepository = platformRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Platform>>> GetAllPlatforms()
        {
            try
            {

                var platforms = await platformRepository.GetAllPlatforms();
                return Ok(platforms);
            }
            catch (Exception ex) {
                return NotFound(ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult<Platform>> AddPlatform(Platform platform)
        {

                var newPlatform = await platformRepository.AddPlatform(platform);
                if(newPlatform == null)
                {
                return BadRequest("Platform not found");
                }

            return Ok(newPlatform);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlatform(int id)
        {
           var foundPlatform = await platformRepository.GetPlatformById(id);
            if (foundPlatform == null)
            {
                return NotFound("Platform not found");
            }
            await platformRepository.DeletePlatform(id);
            return Ok("Platform deleted");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Platform>> GetPlatformById(int id)
        {
            var foundPlatform = await platformRepository.GetPlatformById(id);
            if(foundPlatform == null)
            {
                return NotFound("Platform not found");
            }
            return Ok(foundPlatform);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePlatform(Platform platform)
        {
           await platformRepository.UpdatePlatform(platform);
            return NoContent();
        }
    }
}
