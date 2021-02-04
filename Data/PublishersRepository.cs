using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BooksApi.Data.Entities;
using BooksApi.Models.Repositories;
using Microsoft.Extensions.Logging;

namespace BooksApi.Data
{
    public class PublishersRepository : BaseRepository, IPublishersRepository
    {
        private readonly ILogger<PublishersRepository> _logger;        
        public PublishersRepository(BooksContext context, ILogger<PublishersRepository> logger): base(context)
        {
            _logger = logger;
        }
        public async Task<Data.Entities.Publisher[]> GetPublishers()
        {
            IQueryable<Entities.Publisher> query = _context.Publishers;

            Entities.Publisher[] publishers = await query.ToArrayAsync();

            return publishers;
        }

        public async Task<Data.Entities.Publisher> GetPublisher(int? id)
        {
            var publisher = await _context.Publishers.FindAsync(id);

            return publisher;
        }

        public async Task<Data.Entities.Publisher> PutPublisher(int id, Data.Entities.Publisher publisher)
        {
            _context.Entry(publisher).State = EntityState.Modified;
             await _context.SaveChangesAsync();
             return publisher;
        }

        public async Task<Data.Entities.Publisher> PostPublisher(Data.Entities.Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            await _context.SaveChangesAsync();

            return publisher;
        }

        public async Task<Data.Entities.Publisher> DeletePublisher(int id)
        {
            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher != null){
                _context.Publishers.Remove(publisher);
                await _context.SaveChangesAsync();
                return publisher;
            }
            else return null;

        }
        private bool PublisherrExists(int id)
        {
            return _context.Publishers.Any(e => e.PublisherId == id);
        }
    }
}
