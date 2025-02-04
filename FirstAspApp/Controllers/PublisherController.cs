using FirstAspApp.Interfaces;
using FirstAspApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAspApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherController(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Publisher>> GetAllPublishers()
        {
            var publishers = await _publisherRepository.GetAllPublishers();

            return Ok(publishers);
        }

        [HttpPost]
        public async Task<ActionResult<Publisher>> CreatePublisher(Publisher newPublisher)
        {
            var publisher = await _publisherRepository.AddPublisher(newPublisher);
            return CreatedAtAction(nameof(GetAllPublishers), new { id = newPublisher.Id }, newPublisher);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePublisher(int id)
        {
            var foundPublisher = await _publisherRepository.GetPublisherById(id);

            if(foundPublisher == null)
            {
                return NotFound();
            }

            await _publisherRepository.DeletePublisher(id);
            return Ok("Deleted publisher with Id: " + id + " sucessfully");
        }
    }
}
