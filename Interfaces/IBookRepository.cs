using System.Collections.Generic;
using AspNetCoreBookStore.Models;

namespace AspNetCoreBookStore.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> AllBooks { get; }
        IEnumerable<Book> GetAllBooks()
        {
            return AllBooks;
        }
        IEnumerable<Book> BooksOfTheWeek();
        Book GetBookById(int id);
    }
}