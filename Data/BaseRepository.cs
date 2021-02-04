namespace BooksApi.Data
{
    public abstract class BaseRepository
    {
        protected readonly BooksContext _context;

        public BaseRepository(BooksContext context)
        {
            _context = context;
        }
    }
}