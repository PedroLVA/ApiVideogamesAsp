using FirstAspApp.Interfaces;
using FirstAspApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAspApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperRepository _developerRepository;

        public DeveloperController(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }


        [HttpGet]
        public async Task<ActionResult<Developer>> GetAllDevelopers()
        {
            var developers = await _developerRepository.GetAllDevelopers();
            return Ok(developers);
        }

        [HttpPost]
        public async Task<ActionResult<Developer>> AddDeveloper(Developer developer)
        {
            if (await _developerRepository.GetDeveloperByName(developer.Name) != null)
            {
                return BadRequest("Developer with that name already exists");
            }

            var addedDeveloper = await _developerRepository.AddDeveloper(developer);
            return Ok(addedDeveloper);
        }
    }
}
