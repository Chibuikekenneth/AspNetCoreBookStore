using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreBookStore.Models
{
    public class Book
    {
        public int BookId {  get; set; }
        public String Name { get; set; }
        public string Author { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public  string ImageInformation { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsBookOftheWeek { get; set; }
        public string ImageUrl { get; set; }
        public bool Instock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Notes { get; set; }

    }
}
