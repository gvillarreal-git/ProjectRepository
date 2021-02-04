using System.Collections.Generic;
using System.Threading.Tasks;
using BooksApi.Models.Services;
using BooksApi.Models.Repositories;
using BooksApi.Models;
using BooksApi.Data.Entities;
using AutoMapper;

namespace BooksApi.Services
{
    public class PublisersService : IPublishersService
    {
        private readonly IPublishersRepository _publishersRepository;
        private readonly IMapper _mapper;

        public PublisersService(IPublishersRepository publishersRepository, IMapper mapper)
        {
            this._publishersRepository = publishersRepository;
            _mapper = mapper;
        }

        public async Task<Models.Publisher[]> GetPublishers(){
            var result =  await _publishersRepository.GetPublishers();
            Models.Publisher[] Publishers = _mapper.Map<Models.Publisher[]>(result); 
            return Publishers;
        }

        public async Task<Models.Publisher> GetPublisher(int? id){
            var result =  await _publishersRepository.GetPublisher(id);
            Models.Publisher publisher = _mapper.Map<Models.Publisher>(result); 
            return publisher;
        }

        public async Task<Models.Publisher> PutPublisher(int id, Models.Publisher Publisher){
            Data.Entities.Publisher publisherEnt = _mapper.Map<Data.Entities.Publisher>(Publisher); 
            Data.Entities.Publisher publisherReturn = await _publishersRepository.PutPublisher(id, publisherEnt);
            return _mapper.Map<Models.Publisher>(publisherReturn); 
        }

        public async Task<Models.Publisher> PostPublisher(Models.Publisher Publisher){
            Data.Entities.Publisher publisherEnt = _mapper.Map<Data.Entities.Publisher>(Publisher); 
            var result =  await _publishersRepository.PostPublisher(publisherEnt);
            Models.Publisher PublisherModel = _mapper.Map<Models.Publisher>(result); 
            return PublisherModel;
        }
        public async Task<Models.Publisher> DeletePublisher(int id){
            var result =  await _publishersRepository.DeletePublisher(id);
            Models.Publisher publisherModel = _mapper.Map<Models.Publisher>(result); 
            return publisherModel;
        }
    }
}
