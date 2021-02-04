using System.Collections.Generic;
using System.Threading.Tasks;
using BooksApi.Models;
using BooksApi.Data.Entities;

namespace BooksApi.Models.Services
{
    public interface IAuthorsService
    {
        Task<Author[]> GetAuthors();
        Task<Author> GetAuthor(int? id);

        Task<Author> PutAuthor(int id, Models.Author author);

        Task<Author> PostAuthor(Models.Author author);
        Task<Author> DeleteAuthor(int id);    }
}