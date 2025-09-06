using Clothes.Data;
using Clothes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Security.Claims;

namespace Clothes.Controllers
{

    public class OrderController : Controller
    {
        private readonly ShopContext _context;

        public OrderController(ShopContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int sizeId)
        {
            var product = _context.product
                .Include(p => p.Size)
                .FirstOrDefault(p => p.ID == productId);

            if (product == null) return NotFound();

            var selectedSize = product.Size.FirstOrDefault(s => s.Id == sizeId);

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            Order order = new Order();
            _context.Order.Add(order);
            _context.SaveChanges();

            OrderItem orderItem = new OrderItem
            {
                OrderId = order.OrderId,
                Image = product.ImagePath,
                ProductName = product.Title,
                ProductId = product.ID,
                Price = product.Price,
                Size = product.Sizes,
                Quantity = 1,
                UserId = userId
            };

            _context.OrderItem.Add(orderItem);
            _context.SaveChanges();

            return Redirect("/home");
        }

        public IActionResult ShowCarts()
        {
            var UserID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var resualt = _context.OrderItem.Where(U => U.UserId == UserID).ToList();
            return View(resualt);
        }

    }
}
