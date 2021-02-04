using System.Collections.Generic;
using System.Threading.Tasks;
using BooksApi.Models.Services;
using BooksApi.Models.Repositories;
using BooksApi.Models;
using BooksApi.Data.Entities;
using AutoMapper;

namespace BooksApi.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _bookRepository;
        private readonly IMapper _mapper;

        public BooksService(IBooksRepository bookRepository, IMapper mapper)
        {
            this._bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<Models.Book[]> GetBooks(){
            var result =  await _bookRepository.GetBooks();
            Models.Book[] books = _mapper.Map<Models.Book[]>(result); 
            return books;
        }

        public async Task<Models.Book> GetBook(int? id){
            var result =  await _bookRepository.GetBook(id);
            Models.Book book = _mapper.Map<Models.Book>(result); 
            return book;
        }

        public async Task<Models.Book> PutBook(int id, Models.Book book){
            Data.Entities.Book bookEnt = _mapper.Map<Data.Entities.Book>(book); 
            Data.Entities.Book bookReturn = await _bookRepository.PutBook(id, bookEnt);
            return _mapper.Map<Models.Book>(bookReturn); 
        }

        public async Task<Models.Book> PostBook(Models.Book book){
            Data.Entities.Book bookEnt = _mapper.Map<Data.Entities.Book>(book); 
            var result =  await _bookRepository.PostBook(bookEnt);
            Models.Book bookModel = _mapper.Map<Models.Book>(result); 
            return bookModel;
        }
        public async Task<Models.Book> DeleteBook(int id){
            var result =  await _bookRepository.DeleteBook(id);
            Models.Book bookModel = _mapper.Map<Models.Book>(result); 
            return bookModel;
        }
    }
}
