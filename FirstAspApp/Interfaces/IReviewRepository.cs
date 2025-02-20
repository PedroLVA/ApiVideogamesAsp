using FirstAspApp.Models;

namespace FirstAspApp.Interfaces
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetAllReviews();
        Task<Review> GetReviewById(int id);
        Task DeleteReview(int id);
        Task UpdateReview(Review review);
        Task<Review> AddReview(Review review);
    }
}
