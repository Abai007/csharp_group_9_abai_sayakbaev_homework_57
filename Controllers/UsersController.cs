using homework_54.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_54.Controllers
{
    public class UsersController : Controller
    {
        private StoreContext _db;
        public UsersController(StoreContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<User> users = _db.Users.ToList();
            return View(users);
        }
        public IActionResult Create()
        {
            return RedirectToAction("Register", "Account");
        }
        public IActionResult Editing(int id)
        {
            var brand = _db.Users.FirstOrDefault(b => b.Id == id);
            return View(brand);
        }
        [HttpPost]
        public IActionResult Editing(User user)
        {
            User p = _db.Users.FirstOrDefault(p => p.Id == user.Id);
            p.Email = user.Email;
            _db.Users.Update(p);
            _db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
