using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BooksApi.Models.Services;
using Microsoft.Extensions.Logging;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsService _authorService;

        private readonly ILogger<AuthorsController> _logger;
        

        public AuthorsController(IAuthorsService authorService, ILogger<AuthorsController> logger)
        {
            this._authorService = authorService;
            _logger = logger;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<Models.Author[]>> GetAuthors()
        {
            return await _authorService.GetAuthors();
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Author>> GetAuthor(int? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not found the ID: " + id);
            }

            var author = await _authorService.GetAuthor(id);

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }

        // PUT: api/Authors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, Models.Author author)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not found the ID: " + id);
            }

            if (id != author.AuthorId)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not found the ID: " + id);
            }

            try
            {
                await _authorService.PutAuthor(id, author);
                return StatusCode(StatusCodes.Status200OK, "Author succesfully updated! ");
            }
            catch (DbUpdateConcurrencyException)
            {
                Models.Author authorModel = await _authorService.GetAuthor(id);

                if (authorModel == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Authors
        [HttpPost]
        public async Task<ActionResult<Models.Author>> PostAuthor(Models.Author author)
        {
            if (author==null){
                return StatusCode(StatusCodes.Status400BadRequest, "Bad request, verify the Author's Information ");
            }

            return await _authorService.PostAuthor(author);

        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Author>> DeleteAuthor(int id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Could not found the ID: " + id);
            }

            var author = await _authorService.DeleteAuthor(id);

            if (author == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Could not found the ID: " + id);
            }

            return author;
        }
    }
}
