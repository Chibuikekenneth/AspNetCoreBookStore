using System.Collections.Generic;

namespace AspNetCoreBookStore.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public ICollection<Book> books { get; set; }
        public Category()
        {
            books = new HashSet<Book>();
        }
    }
}