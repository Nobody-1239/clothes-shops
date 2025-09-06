using Clothes.Data;
using Clothes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clothes.Controllers
{
    public class AdminController : Controller
    {
        private readonly ShopContext _context;
        public AdminController(ShopContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var resualt = _context.product.Include(C => C.category).ToList();
            return View(resualt);
        }

        [HttpPost]
        public IActionResult AddToProduct(product product, IFormFile ImageFile)
        {
            if (product == null)
            {
                return View(product);

            }
            if (ImageFile != null && ImageFile.Length > 0)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(ImageFile.FileName);
                var path = Path.Combine("wwwroot/images", fileName);

                using var stream = new FileStream(path, FileMode.Create);
                ImageFile.CopyTo(stream);

                product.ImagePath = "/images/" + fileName;


                var Product = new product
                {
                    Title = product.Title,
                    Description = product.Description,
                    Price = product.Price,
                    Size = product.Size,
                    CategoryID = product.CategoryID,
                    ImagePath = "/images/" + fileName
                };
            }
            
            _context.product.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
