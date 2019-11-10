using System.Collections.Generic;
using AspNetCoreBookStore.Models;

namespace AspNetCoreBookStore.ViewModels
{
    public class BookListViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public string CurrentCategory { get; set; }
    }
}