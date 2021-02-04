using System.Collections.Generic;
using System.Threading.Tasks;
using BooksApi.Models;
using BooksApi.Data.Entities;

namespace BooksApi.Models.Services
{
    public interface IBooksService
    {
        Task<Book[]> GetBooks();
        Task<Book> GetBook(int? id);

        Task<Book> PutBook(int id, Models.Book book);

        Task<Book> PostBook(Models.Book book);
        Task<Book> DeleteBook(int id);    }
}