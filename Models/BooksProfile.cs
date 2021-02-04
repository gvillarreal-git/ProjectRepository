using AutoMapper;

namespace BooksApi.Models
{
    public class BooksProfile: Profile{
        public BooksProfile(){
            CreateMap<Data.Entities.Author, Models.Author>();
            CreateMap<Data.Entities.Publisher, Models.Publisher>();
            CreateMap<Data.Entities.Book, Models.Book>();

            CreateMap<Models.Author, Data.Entities.Author>();
            CreateMap<Models.Publisher, Data.Entities.Publisher>();
            CreateMap<Models.Book, Data.Entities.Book>();
        }
    }
}