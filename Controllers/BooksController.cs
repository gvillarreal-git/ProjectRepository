using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using BooksApi.Models.Services;
using BooksApi.Services;


namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _bookService;
        
        public BooksController(IBooksService booksherService)
        {
            this._bookService = booksherService;
        }


        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<Models.Book[]>> GetBooks()
        {
            return await _bookService.GetBooks();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Book>> GetBook(int? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not found the ID: " + id);
            }

            var book = await _bookService.GetBook(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Models.Book book)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not found the ID: " + id);
            }

            if (id != book.BookId)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not found the ID: " + id);
            }
            
            try
            {
                await _bookService.PutBook(id, book);
                return StatusCode(StatusCodes.Status200OK, "Book succesfully updated! ");
            }
            catch (DbUpdateConcurrencyException)
            {
                Models.Book bookModel = await _bookService.GetBook(id);

                if (bookModel == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<Models.Book>> PostBook(Models.Book book)
        {
            if (book==null){
                return StatusCode(StatusCodes.Status400BadRequest, "Bad request, verify the Book's Information ");
            }
            
            var result = await _bookService.PostBook(book);
            return result;
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Book>> DeleteBook(int id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Could not found the ID: " + id);
            }

            var book = await _bookService.DeleteBook(id);

            if (book == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Could not found the ID: " + id);
            }

            return book;
        }
    }
}
