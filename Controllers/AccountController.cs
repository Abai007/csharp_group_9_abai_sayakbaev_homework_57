using homework_54.Models;
using homework_54.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace homework_54.Controllers
{
    public class AccountController : Controller
    {
        private StoreContext _db;

        public AccountController(StoreContext db)

        {

            _db = db;

        }


        [HttpGet]

        public IActionResult Login()

        {

            return View();

        }



        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Login(LoginViewModel model)

        {
            
            if (ModelState.IsValid)

            {

                User user = await _db.Users

                    .Include(u => u.Role)

                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);

                if (user != null)

                {
                    
                    ViewBag.User = user;
                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Index", "Home");

                }

                ModelState.AddModelError("", "Некорректные логин и(или) пароль");

            }
            
            return View(model);

        }


        [HttpGet]

        public IActionResult Register()

        {

            return View();

        }


        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    user = new User { Email = model.Email, Password = model.Password };
                    Role userRole = await _db.Roles.FirstOrDefaultAsync(r => r.Name == "user");

                    if (userRole != null)
                        user.Role = userRole;

                    _db.Users.Add(user);
                    await _db.SaveChangesAsync();

                    await Authenticate(user);
                    
                    return RedirectToAction("Login", "Account");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");

            }

            return View(model);

        }
        private async Task Authenticate(User user)

        {

            var claims = new List<Claim>

                {

                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),

                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)

                };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(

                        CookieAuthenticationDefaults.AuthenticationScheme,

                        new ClaimsPrincipal(id),

                        new AuthenticationProperties

                        {

                            IsPersistent = true,

                            ExpiresUtc = DateTime.UtcNow.AddMinutes(1)

                        }

                       );
        }
        public async Task<IActionResult> Logout()

        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Account");

        }
        [Authorize(Roles = "admin")]
        public IActionResult Test()

        {

            return Json("Hello World");

        }
    }
}
