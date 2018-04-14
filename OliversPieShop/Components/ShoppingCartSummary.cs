using Microsoft.AspNetCore.Mvc;
using OliversPieShop.Models;
using OliversPieShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OliversPieShop.Components
{
    public class ShoppingCartSummary: ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            //works tru dependency injection
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            //all code in here gets called automatically upon partial view being called

            //below line is commented so mock items can be added to db
            var items = _shoppingCart.GetShoppingCartItems();

            //below line add 2 mock items to shopping cart
            //var items = new List<ShoppingCartItem>() { new ShoppingCartItem(), new ShoppingCartItem() };
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }
    }
}
