using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BooksApi.Data.Entities;
using BooksApi.Models.Repositories;
using Microsoft.Extensions.Logging;

namespace BooksApi.Data
{
    public class BooksRepository : BaseRepository, IBooksRepository
    {
        private readonly ILogger<BooksRepository> _logger;        
        public BooksRepository(BooksContext context, ILogger<BooksRepository> logger): base(context)
        {
            _logger = logger;
        }
        public async Task<Data.Entities.Book[]> GetBooks()
        {
            IQueryable<Entities.Book> query = _context.Books
            .Include(a => a.Author)
            .Include(b => b.Publisher);

            Entities.Book[] books = await query.ToArrayAsync();

            return books;
        }

        public async Task<Data.Entities.Book> GetBook(int? id)
        {
            var book = await _context.Books
            .Include(a => a.Author)
            .Include(b => b.Publisher)
            .FirstOrDefaultAsync(i => i.BookId == id.Value);

            return book;
        }

        public async Task<Data.Entities.Book> PutBook(int id, Data.Entities.Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
             await _context.SaveChangesAsync();
             return book;
        }

        public async Task<Data.Entities.Book> PostBook(Data.Entities.Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task<Data.Entities.Book> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null){
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return book;
            }
            else return null;

        }
        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookId == id);
        }
    }
}
