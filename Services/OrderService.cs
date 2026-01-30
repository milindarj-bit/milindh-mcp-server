using myapp.Data;
using myapp.Models;
using System.Collections.Generic;
using System.Linq;

namespace myapp.Services
{
    public class OrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateOrder(string userId, List<CartItem> cartItems)
        {
            var order = new Order
            {
                UserId = userId,
                Total = cartItems.Sum(ci => ci.Price * ci.Quantity),
                OrderDetails = cartItems.Select(ci => new OrderDetail
                {
                    BiryaniId = ci.Biryani.Id,
                    Quantity = ci.Quantity,
                    Price = ci.Price
                }).ToList()
            };

            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}
