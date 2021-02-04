using System.Collections.Generic;
using System.Threading.Tasks;
using BooksApi.Models.Services;
using BooksApi.Models.Repositories;
using BooksApi.Models;
using BooksApi.Data.Entities;
using AutoMapper;
using Microsoft.Extensions.Logging;



namespace BooksApi.Services
{
    public class AuthorsService : IAuthorsService
    {
        private readonly IAuthorsRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthorsService> _logger;        

        public AuthorsService(IAuthorsRepository authorRepository, IMapper mapper, ILogger<AuthorsService> logger)
        {
            this._authorRepository = authorRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Models.Author[]> GetAuthors(){
            var result =  await _authorRepository.GetAuthors();
            Models.Author[] authors = _mapper.Map<Models.Author[]>(result); 
            return authors;
        }

        public async Task<Models.Author> GetAuthor(int? id){
            var result =  await _authorRepository.GetAuthor(id);
            Models.Author author = _mapper.Map<Models.Author>(result); 
            return author;
        }

        public async Task<Models.Author> PutAuthor(int id, Models.Author author){
            Data.Entities.Author authorEnt = _mapper.Map<Data.Entities.Author>(author); 
            Data.Entities.Author authorReturn = await _authorRepository.PutAuthor(id, authorEnt);
            return _mapper.Map<Models.Author>(authorReturn); 
        }

        public async Task<Models.Author> PostAuthor(Models.Author author){
            _logger.LogInformation($" ***** Inicia.");
            Data.Entities.Author authorEnt = _mapper.Map<Data.Entities.Author>(author); 
            var result =  await _authorRepository.PostAuthor(authorEnt);
            Models.Author authorModel = _mapper.Map<Models.Author>(result); 
            return authorModel;
        }
        public async Task<Models.Author> DeleteAuthor(int id){
            var result =  await _authorRepository.DeleteAuthor(id);
            Models.Author authorModel = _mapper.Map<Models.Author>(result); 
            return authorModel;
        }
    }
}
