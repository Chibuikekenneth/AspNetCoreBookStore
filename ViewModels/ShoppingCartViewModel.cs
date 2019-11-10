using AspNetCoreBookStore.Models;

namespace AspNetCoreBookStore.ViewModels
{
    public class ShoppingCartViewModel
    {
        public decimal ShoppingCartTotal;
        public ShoppingCart ShoppingCart { get; internal set; }
    }
}