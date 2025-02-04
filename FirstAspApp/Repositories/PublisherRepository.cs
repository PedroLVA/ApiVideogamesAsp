using FirstAspApp.Data;
using FirstAspApp.Interfaces;
using FirstAspApp.Models;

namespace FirstAspApp.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly VideoGameDbContext _context;

        public PublisherRepository(VideoGameDbContext context) {
            _context = context;
        }

        public Task<Publisher> AddPublisher(Publisher publisher)
        {
            throw new NotImplementedException();
        }

        public Task DeletePublisher(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Publisher>> GetAllPublishers()
        {
            throw new NotImplementedException();
        }

        public Task<Publisher?> GetPublisherById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePublisher(Publisher publisher)
        {
            throw new NotImplementedException();
        }
    }
}
