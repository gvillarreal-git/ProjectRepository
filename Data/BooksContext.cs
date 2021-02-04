using BooksApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Data
{

    public class BooksContext: DbContext {
        public BooksContext(DbContextOptions options): base(options){ }

        protected override void OnModelCreating(ModelBuilder builder){

            builder.Entity<Book>().Property(p => p.BookId);
            builder.Entity<Author>().Property(p => p.AuthorId);
            builder.Entity<Publisher>().Property(p => p.PublisherId);

            builder.Entity<Book>().ToTable("Book").HasOne(x => x.Publisher);
            builder.Entity<Author>().ToTable("Author");
            builder.Entity<Publisher>().ToTable("Publisher");

        }

        public DbSet<BooksApi.Data.Entities.Book> Books { get; set; }
        public DbSet<BooksApi.Data.Entities.Author> Authors { get; set; }
        public DbSet<BooksApi.Data.Entities.Publisher> Publishers { get; set; }
    }

}