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
    public class AuthorsRepository : BaseRepository, IAuthorsRepository
    {
        private readonly ILogger<AuthorsRepository> _logger;        
        public AuthorsRepository(BooksContext context, ILogger<AuthorsRepository> logger): base(context)
        {
            _logger = logger;
        }
        public async Task<Data.Entities.Author[]> GetAuthors()
        {
            IQueryable<Entities.Author> query = _context.Authors;

            Entities.Author[] authors = await query.ToArrayAsync();

            return authors;
        }

        public async Task<Data.Entities.Author> GetAuthor(int? id)
        {
            var author = await _context.Authors.FindAsync(id);

            return author;
        }

        public async Task<Data.Entities.Author> PutAuthor(int id, Data.Entities.Author author)
        {
            _context.Entry(author).State = EntityState.Modified;
             await _context.SaveChangesAsync();
             return author;
        }

        public async Task<Data.Entities.Author> PostAuthor(Data.Entities.Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return author;
        }

        public async Task<Data.Entities.Author> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author != null){
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
                return author;
            }
            else return null;

        }
        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.AuthorId == id);
        }
    }
}
