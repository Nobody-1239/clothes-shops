using Clothes.Data;
using Clothes.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Security.Claims;

namespace Clothes.Controllers
{
    public class AccountController : Controller
    {
        private readonly ShopContext _context;
        public AccountController(ShopContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var ExistAccount = _context.User.SingleOrDefault(U => U.Email == user.Email && U.FirstName == user.FirstName);
            if (ExistAccount != null)
            {
                if (ExistAccount.Password == user.Password)
                {
                    var claims = new List<Claim>
                    {
                       new Claim(ClaimTypes.NameIdentifier, ExistAccount.Id.ToString()),
                       new Claim(ClaimTypes.Name, ExistAccount.Email),
                       new Claim("FullName", ExistAccount.FirstName + " " + ExistAccount.LastName)
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
                    };
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        principal,
                        authProperties
                    );

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Incorrect password.");
                    return View(user);
                }
            }
            else
            {
                var newUser = new User
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password
                };

                _context.User.Add(newUser);
                _context.SaveChanges();

                var claims = new List<Claim>
                { 
                  new Claim(ClaimTypes.NameIdentifier, newUser.Id.ToString()),
                  new Claim(ClaimTypes.Name, newUser.Email),
                  new Claim("FullName", newUser.FirstName + " " + newUser.LastName)
                };


                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    principal,
                    authProperties
                );
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public JsonResult CheckEmailExists(string email)
        {
            bool exists = _context.User.Any(u => u.Email == email);
            return Json(new { exists });
        }

    }
}
