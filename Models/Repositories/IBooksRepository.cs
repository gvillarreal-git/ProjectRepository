using System.Threading.Tasks;
using BooksApi.Data.Entities;
using BooksApi.Data;

namespace BooksApi.Models.Repositories
{
    public interface IBooksRepository
    {
        public Task<Data.Entities.Book[]> GetBooks();
        public Task<Data.Entities.Book> GetBook(int? id);

        public Task<Data.Entities.Book> PutBook(int id, Data.Entities.Book author);

        public Task<Data.Entities.Book> PostBook(Data.Entities.Book author);
        public Task<Data.Entities.Book> DeleteBook(int id);
    }
}
