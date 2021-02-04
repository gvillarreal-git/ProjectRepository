using System.Threading.Tasks;
using BooksApi.Data.Entities;
using BooksApi.Data;

namespace BooksApi.Models.Repositories
{
    public interface IPublishersRepository
    {
        public Task<Data.Entities.Publisher[]> GetPublishers();
        public Task<Data.Entities.Publisher> GetPublisher(int? id);

        public Task<Data.Entities.Publisher> PutPublisher(int id, Data.Entities.Publisher Publisher);

        public Task<Data.Entities.Publisher> PostPublisher(Data.Entities.Publisher Publisher);
        public Task<Data.Entities.Publisher> DeletePublisher(int id);
    }
}
