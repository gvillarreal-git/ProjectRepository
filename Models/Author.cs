using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace BooksApi.Models
{
    public class Author
    {
        public int AuthorId {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}

        public List<Book> books {get; set;}
        // public date CreateDate {get; set;}
        // public Date DeleteDate {get; set;}
        // public Date LastUpdate {get; set;}
    }

}