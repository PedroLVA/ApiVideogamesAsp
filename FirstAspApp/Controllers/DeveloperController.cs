using FirstAspApp.Interfaces;
using FirstAspApp.Models;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<Developer>> GetDeveloper(int id)
        {
            try
            {
                var foundDeveloper = await _developerRepository.GetDeveloperById(id);
                return Ok(foundDeveloper);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
           
        }

        [HttpPost]
        public async Task<ActionResult<Developer>> AddDeveloper(Developer developer)
        {
            try
            {
                var addedDeveloper = await _developerRepository.AddDeveloper(developer);
                return Ok(addedDeveloper);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDeveloper(int id)
        {
            try
            {
                await _developerRepository.DeleteDeveloper(id);
                return Ok("Deleted developer with Id " + id + " successfully!");
            }
            catch(Exception ex) { 
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public async Task<ActionResult> UpdateDeveloper(Developer developer)
        {
            try
            {
                await _developerRepository.UpdateDeveloper(developer);
                return Ok("Updated developer with Id " + developer.Id + " successfully!");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
