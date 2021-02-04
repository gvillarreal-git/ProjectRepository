using System.Threading.Tasks;
using BooksApi.Data.Entities;
using BooksApi.Data;

namespace BooksApi.Models.Repositories
{
    public interface IAuthorsRepository
    {
        public Task<Data.Entities.Author[]> GetAuthors();
        public Task<Data.Entities.Author> GetAuthor(int? id);

        public Task<Data.Entities.Author> PutAuthor(int id, Data.Entities.Author author);

        public Task<Data.Entities.Author> PostAuthor(Data.Entities.Author author);
        public Task<Data.Entities.Author> DeleteAuthor(int id);
    }
}
