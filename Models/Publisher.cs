using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace BooksApi.Models
{
    public class Publisher
    {
        public int PublisherId {get; set;}
        public string Name {get; set;}
        public string Location {get; set;}


        // public date CreateDate {get; set;}
        // public Date DeleteDate {get; set;}
        // public Date LastUpdate {get; set;}
    }

}