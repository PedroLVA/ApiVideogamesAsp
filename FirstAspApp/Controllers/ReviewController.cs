using FirstAspApp.Interfaces;
using FirstAspApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstAspApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Review>> addReview(Review review, int gameId)
        {
            try
            {
                await _reviewRepository.AddReview(review);
                return Ok(review);
            }
            catch(Exception ex) { 
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public async Task<ActionResult<List<Review>>> GetAllReviews()
        {
            return await _reviewRepository.GetAllReviews();
        }

        [HttpGet("{id}")]
      
        public async Task<ActionResult<Review>> GetReviewById(int id)
        {
            try
            {
                return await _reviewRepository.GetReviewById(id);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReview(int id)
        {
            var reviewToBeDelete = await _reviewRepository.GetReviewById(id);

            if (reviewToBeDelete == null)
            {
                return BadRequest();

            }

            await _reviewRepository.DeleteReview(id);
            return Ok();

        }

        [HttpPut]
        public async Task<ActionResult> UpdateReview(Review review)
        {
            var reviewToBeUpdated = await _reviewRepository.GetReviewById(review.Id);
            if (reviewToBeUpdated == null)
            {
                return BadRequest();
            }
            await _reviewRepository.UpdateReview(review);
            return Ok();
        }


    }
}
