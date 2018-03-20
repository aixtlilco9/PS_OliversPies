using OliversPieShop.Models;

namespace OliversPieShop.Components
{
    internal class ShoppingCartViewModel
    {
        public decimal ShoppingCartTotal { get; internal set; }
        public ShoppingCart ShoppingCart { get; internal set; }
    }
}