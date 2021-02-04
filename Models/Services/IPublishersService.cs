using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksApi.Models.Services
{
    public interface IPublishersService
    {
        Task<Publisher[]> GetPublishers();
        Task<Publisher> GetPublisher(int? id);

        Task<Publisher> PutPublisher(int id, Models.Publisher publisher);

        Task<Publisher> PostPublisher(Models.Publisher publisher);
        Task<Publisher> DeletePublisher(int id);    
    }
}