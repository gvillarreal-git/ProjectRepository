using System.ComponentModel.DataAnnotations;

namespace BooksApi.Models
{
    public class Book
    {
        public int BookId {get; set;}
        public string Title {get; set;}
        public string Summary {get; set;}
        public string Isbn {get; set;}

        public int AuthorId {get; set;}
        public Author Author {get; set;}
        public int PublisherId {get; set;}
        public Publisher Publisher {get; set;}
        // public date CreateDate {get; set;}
        // public Date DeleteDate {get; set;}
        // public Date LastUpdate {get; set;}
    }

}