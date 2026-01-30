using Microsoft.AspNetCore.Mvc;
using myapp.Data;
using myapp.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using myapp.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace myapp.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly OrderService _orderService;

        public CartController(ApplicationDbContext context, OrderService orderService)
        {
            _context = context;
            _orderService = orderService;
        }

        public IActionResult AddToCart(int id)
        {
            var biryani = _context.Biryanis.Find(id);
            if (biryani == null)
            {
                return NotFound();
            }

            var cart = GetCart();
            var cartItem = cart.FirstOrDefault(i => i.Biryani.Id == id);

            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                cart.Add(new CartItem { Biryani = biryani, Quantity = 1, Price = biryani.Price });
            }

            SaveCart(cart);

            // Redirect to the previous page
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }

        [Authorize]
        public IActionResult Checkout()
        {
            var cart = GetCart();
            if (cart.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _orderService.CreateOrder(userId, cart);

            HttpContext.Session.Remove("Cart");

            return View("OrderConfirmation");
        }

        private List<CartItem> GetCart()
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            if (string.IsNullOrEmpty(cartJson))
            {
                return new List<CartItem>();
            }
            return JsonConvert.DeserializeObject<List<CartItem>>(cartJson);
        }

        private void SaveCart(List<CartItem> cart)
        {
            var cartJson = JsonConvert.SerializeObject(cart);
            HttpContext.Session.SetString("Cart", cartJson);
        }
    }
}
