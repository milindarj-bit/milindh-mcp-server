using Microsoft.AspNetCore.Mvc;
using myapp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace myapp.ViewComponents
{
    public class CartCountViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            var cart = string.IsNullOrEmpty(cartJson) ? new List<CartItem>() : JsonConvert.DeserializeObject<List<CartItem>>(cartJson);
            var itemCount = cart.Sum(item => item.Quantity);

            return View(itemCount);
        }
    }
}
