using System.Diagnostics;
using Clothes.Data;
using Clothes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clothes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShopContext _context;

        public HomeController(ILogger<HomeController> logger, ShopContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var resualt = _context.product.OrderByDescending(product => product.ID).Take(3).ToList();
            return View(resualt);
        }

       [Authorize]
        public IActionResult Detail(int id)
        {
            var resualt = _context.product
                   .Include(product => product.Size)
                   .Where(Product => Product.ID == id).ToList();
            if (resualt == null)
                return NotFound();

            return View(resualt);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
