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

        public async Task<Publisher> AddPublisher(Publisher publisher)
        {
            await _context.Publishers.AddAsync(publisher);

            return publisher;
        }

        public async Task DeletePublisher(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Publisher>> GetAllPublishers()
        {
            throw new NotImplementedException();
        }

        public async Task<Publisher?> GetPublisherById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdatePublisher(Publisher publisher)
        {
            throw new NotImplementedException();
        }
    }
}
