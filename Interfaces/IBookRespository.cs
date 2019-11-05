using System.Collections.Generic;
using AspNetCoreBookStore.Models;

namespace AspNetCoreBookStore.Interfaces
{
    public interface IBookRespository
    {
        IEnumerable<Book> AllBooks { get; }
        IEnumerable<Book> BooksOfTheWeek();
        Book GetBookById(int id);
    } 
}