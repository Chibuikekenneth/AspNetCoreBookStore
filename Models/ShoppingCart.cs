using System;
using System.Collections.Generic;
using System.Linq;
using AspNetCoreBookStore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreBookStore.Models
{
    public class ShoppingCart
    {
        private readonly ApplicationDbContext _appDbContext;
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        private ShoppingCart(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            
            var context = services.GetService<ApplicationDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId};
        }

        public void AddToCart(Book book, int amount)
        {
            //get the matching shoppingCartItem and book instances
            var shoppingCartItem = _appDbContext.ShoppingCartItems.SingleOrDefault(
                s => s.Book.BookId == book.BookId && s.ShoppingCartId == ShoppingCartId
            );

            if (shoppingCartItem == null)
            {
                //create  new shoppingCartItem if no shoppingCartItem exist
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Book = book,
                    Amount = 1
                };

                _appDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else 
            {
                //if that particular item does exist in the shoppingCart, then add one to the quantity
                shoppingCartItem.Amount++;
            }
            //save changes
            _appDbContext.SaveChanges();
        }

        public int RemoveFromCart(Book book)
        {
            var shoppingCartItem = _appDbContext.ShoppingCartItems.SingleOrDefault(
                s => s.Book.BookId == book.BookId && s.ShoppingCartId == ShoppingCartId
            );

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                //if the Amount or count for a particular item is greater than 1
                if(shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }

                //else remove that item from the Table
                else 
                {
                    _appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _appDbContext.SaveChanges();
            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _appDbContext.ShoppingCartItems.Where(c =>                             c.ShoppingCartId == ShoppingCartId)
                        .Include(s => s.Book)
                        .ToList()
                );
        }

        public void ClearCart()
        {
            var cartItems = _appDbContext.ShoppingCartItems.Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _appDbContext.ShoppingCartItems.RemoveRange(cartItems);
            _appDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).Select(c => c.Book.Price * c.Amount).Sum();
            return total;
        }
    }
}