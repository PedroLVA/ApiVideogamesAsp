using FirstAspApp.Interfaces;
using FirstAspApp.Models;

namespace FirstAspApp.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        public Task<Review> AddReview(Review review)
        {
            throw new NotImplementedException();
        }

        public Task DeleteReview(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Review>> GetAllReviews()
        {
            throw new NotImplementedException();
        }

        public Task<Review> GetReviewById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateReview(Review review)
        {
            throw new NotImplementedException();
        }
    }
}
