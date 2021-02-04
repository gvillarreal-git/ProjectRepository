using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BooksApi.Data;
using BooksApi.Models;
using BooksApi.Models.Services;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublishersService _publisherService;

        public PublishersController(IPublishersService publisherService)
        {
            this._publisherService = publisherService;
        }

        // GET: api/Publishers
        [HttpGet]
        public async Task<ActionResult<Models.Publisher[]>> GetPublishers()
        {
            return await _publisherService.GetPublishers();
        }

        // GET: api/Publishers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Publisher>> GetPublisher(int? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not found the ID: " + id);
            }

            var publisher = await _publisherService.GetPublisher(id);

            if (publisher == null)
            {
                return NotFound();
            }

            return publisher;
        }

        // PUT: api/Publishers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublisher(int id, Models.Publisher publisher)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not found the ID: " + id);
            }

            if (id != publisher.PublisherId)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not found the ID: " + id);
            }

            try
            {
                await _publisherService.PutPublisher(id, publisher);
                return StatusCode(StatusCodes.Status200OK, "Publisher succesfully updated! ");
            }
            catch (DbUpdateConcurrencyException)
            {
                Models.Publisher publisherModel = await _publisherService.GetPublisher(id);

                if (publisherModel == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Publishers
        [HttpPost]
        public async Task<ActionResult<Models.Publisher>> PostPublisher(Models.Publisher publisher)
        {
            if (publisher==null){
                return StatusCode(StatusCodes.Status400BadRequest, "Bad request, verify the Publisher's Information ");
            }

            return await _publisherService.PostPublisher(publisher);

        }

        // DELETE: api/Publishers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Publisher>> DeletePublisher(int id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Could not found the ID: " + id);
            }

            var publisher = await _publisherService.DeletePublisher(id);

            if (publisher == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Could not found the ID: " + id);
            }

            return publisher;
        }
    }
}
