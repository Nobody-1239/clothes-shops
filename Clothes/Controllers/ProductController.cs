using Clothes.Data;
using Clothes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clothes.Controllers
{
    public class ProductController : Controller
    {
        private readonly ShopContext _context;
        public ProductController(ShopContext context)
        {
            _context = context;
        }
        public IActionResult Show()
        {
            var product = _context.product.ToList();
            return View(product);
        }
        public IActionResult Categories(int categoryId)
        {
           var resualt = _context.product.Where(C => C.CategoryID == categoryId).ToList();
            return View(resualt);
        }
    }
}
