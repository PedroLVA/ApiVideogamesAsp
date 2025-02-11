using FirstAspApp.Data;
using FirstAspApp.Interfaces;
using FirstAspApp.Models;

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
            _context.Reviews.Add(review);

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
            throw new NotImplementedException();
        }

        public async Task<Review> GetReviewById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateReview(Review review)
        {
            throw new NotImplementedException();
        }
    }
}
