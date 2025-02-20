using FirstAspApp.Data;
using FirstAspApp.Interfaces;
using FirstAspApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAspApp.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly VideoGameDbContext _context;

        public ReviewRepository(VideoGameDbContext context)
        {
            _context = context;
        }


        public async Task<Review> AddReview(Review review)
        {
            var foundGame = await _context.VideoGames.Include(vg => vg.Reviews).FirstOrDefaultAsync(vg => vg.Id == review.VideoGameId);

            if (foundGame == null)
            {
                throw new Exception("Game not found");
            }

            if (foundGame.Reviews.Count == 0)
            {
                foundGame.Reviews = new List<Review>(); 
            }

            foundGame.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review;


        }

        public async Task DeleteReview(int id)
        {
            var foundReview = await _context.Reviews.FindAsync(id);

            _context.Reviews.Remove(foundReview);
            await _context.SaveChangesAsync();

            return;

        }

        public async Task<List<Review>> GetAllReviews()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<Review> GetReviewById(int id)
        {
            var foundReview = await _context.Reviews.FirstOrDefaultAsync(r => r.Id == id);
            if(foundReview == null)
            {
                throw new Exception("Review not found");
            }

            return foundReview;
        }

        public async Task UpdateReview(Review review)
        {
            var reviewToBeUpdated = await _context.Reviews.FirstOrDefaultAsync(r => r.Id == review.Id);

            if (reviewToBeUpdated == null)
            {
                throw new Exception("Review not found");
            }

            reviewToBeUpdated.Rating = review.Rating;
            reviewToBeUpdated.Comment = review.Comment;

            await _context.SaveChangesAsync();

            return;
        }
    }
}
