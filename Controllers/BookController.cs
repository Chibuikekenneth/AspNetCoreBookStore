using System;
using System.Collections.Generic;
using System.Linq;
using AspNetCoreBookStore.Interfaces;
using AspNetCoreBookStore.Models;
using AspNetCoreBookStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreBookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepo;
        public BookController(IBookRepository bookRepository, ICategoryRepository categoryRepo)
        {
            _bookRepository = bookRepository;
            _categoryRepo = categoryRepo;
        }

        public ViewResult List(string category)
        {
            IEnumerable<Book> books;
            string currentCategory = null;

            if (string.IsNullOrEmpty(category))
            {
                books = _bookRepository.GetAllBooks().OrderBy(p => p.BookId);
            }
            else
            {
                books = _bookRepository.GetAllBooks().Where(p => p.Category.CategoryName == category).OrderBy(p => p.BookId);
                currentCategory = _categoryRepo.AllCategorys.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new BookListViewModel
            {
                Books = books,
                CurrentCategory = currentCategory  
            });
        }

        public IActionResult Details(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if(book == null) return NotFound();
            return View(book);
        }
    }
}