using System;
using System.Collections.Generic;
using AspNetCoreBookStore.Data;
using AspNetCoreBookStore.Interfaces;
using AspNetCoreBookStore.Models;

namespace AspNetCoreBookStore.Repository
{
    public class OrderRepository: IOrderRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(ApplicationDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            
            var shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();
            order.OrderDetails = new List<OrderDetail>();

            //adding the order with its details

            foreach (var shoppingCartItem in shoppingCartItems) 
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount, 
                    Price = shoppingCartItem.Book.Price
                };

                order.OrderDetails.Add(orderDetail);
            }
            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();
        }
    }
}