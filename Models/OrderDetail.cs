using System;

namespace AspNetCoreBookStore.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Book Book { get; set; }
        public Order Order { get; set; }
    }
}