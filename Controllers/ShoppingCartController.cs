using System;
using System.Linq;
using AspNetCoreBookStore.Interfaces;
using AspNetCoreBookStore.Models;
using AspNetCoreBookStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreBookStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IBookRepository _repository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IBookRepository repository, ShoppingCart shoppingCart)
        {
            _repository = repository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var Items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = Items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()

            };
            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int id)
        {
            var selectedBook = _repository.GetAllBooks().FirstOrDefault(p => p.BookId == id);

            if (selectedBook != null)
            {
                _shoppingCart.AddToCart(selectedBook, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int bookId)
        {
            var selectedBook = _repository.GetAllBooks().FirstOrDefault(p => p.BookId == bookId);

            if (selectedBook != null)
            {
                _shoppingCart.RemoveFromCart(selectedBook);
            }
            return RedirectToAction("Index");
        }
    }
}