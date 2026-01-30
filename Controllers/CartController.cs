using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myapp.Models;
using System.Collections.Generic;
using System.Text.Json;

namespace myapp.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }

        [HttpPost]
        public IActionResult AddToCart(string name)
        {
            var cart = GetCart();
            var existingItem = cart.Find(item => item.Name == name);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                decimal price = 0;
                switch (name)
                {
                    case "Chicken Biryani":
                        price = 450;
                        break;
                    case "Mutton Biryani":
                        price = 550;
                        break;
                    case "Vegetable Biryani":
                        price = 350;
                        break;
                }
                cart.Add(new CartItem { Name = name, Price = price, Quantity = 1 });
            }

            SaveCart(cart);
            return RedirectToAction("Index");
        }

        public IActionResult Checkout()
        {
            HttpContext.Session.Remove("Cart");
            return View();
        }

        private List<CartItem> GetCart()
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            if (string.IsNullOrEmpty(cartJson))
            {
                return new List<CartItem>();
            }
            var cart = JsonSerializer.Deserialize<List<CartItem>>(cartJson);
            return cart ?? new List<CartItem>();
        }

        private void SaveCart(List<CartItem> cart)
        {
            var cartJson = JsonSerializer.Serialize(cart);
            HttpContext.Session.SetString("Cart", cartJson);
        }
    }
}
