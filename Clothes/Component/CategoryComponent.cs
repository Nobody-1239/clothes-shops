using Microsoft.AspNetCore.Mvc;
using Clothes.Data;
using Microsoft.EntityFrameworkCore;
using Clothes.Models;

namespace news.Component
{
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly ShopContext _context;

        public CategoryListViewComponent(ShopContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var post = _context.Category
                .Select(c => new Category
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToList();

            return View(post);

        }
    }
}