using System.Collections.Generic;
using System.Linq;
using AspNetCoreBookStore.Data;
using AspNetCoreBookStore.Interfaces;
using AspNetCoreBookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreBookStore.Repository
{
    public class BookRepository: IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> AllBooks
        {
            get
            {
                return _context.Books.Include(c => c.Category);
            }
        }

        public IEnumerable<Book> BooksOfTheWeek()
        {
            return _context.Books.Include(c => c.Category).Where(x => x.IsBookOftheWeek);
        }

        public Book GetBookById(int id)
        {
            return _context.Books.Include(c => c.Category).FirstOrDefault(x => x.BookId == id);
        }
    }
}