using Clothes.Data;
using Clothes.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Clothes.Data;
using System.Security.Claims;
using System.Threading.Tasks;

namespace news.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class IsAdmin
    {
        private readonly RequestDelegate _next;
        private readonly ShopContext _context;
        public IsAdmin(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ShopContext database)
        {
            var path = httpContext.Request.Path;
            var CurentUser = httpContext.Session.GetString("username");

            if (path.StartsWithSegments("/admin"))
            {
                var UserId = int.Parse(httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                var isAdmin = database.User.Where(Id => Id.Id == UserId).Select(Admin => Admin.IsAdmin).FirstOrDefault();

                if (isAdmin == false)
                {
                    httpContext.Response.Redirect("/AccessDenied");
                    return;
                }
            }
            await _next(httpContext);
        }

    }
    public static class IsAdminExtensions
    {
        public static IApplicationBuilder UseIsAdmin(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<IsAdmin>();
        }
    }
}