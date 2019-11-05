using System.Collections.Generic;
using AspNetCoreBookStore.Models;

namespace AspNetCoreBookStore.Interfaces
{
    public interface IBookService
    {
         IEnumerable<Book> GetAllBooks();
         Book GetBookById(int id);
         IEnumerable<Book> GetBooksOfTheWeek();
    }
}