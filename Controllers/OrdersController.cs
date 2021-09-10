using homework_54.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_54.Controllers
{
    [Authorize(Roles = "user")]
    public class OrdersController : Controller
    {
        private StoreContext _db;

        public OrdersController(StoreContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            if(User.Identity.Name != "admin@admin.admin")
            {
                List<Order> orders = _db.Orders.Include(o => o.Product).ToList();
                return View(orders);
            }else
            {
                return RedirectToAction("Login", "Account");
            }
           
        }


        public IActionResult Create(int productId)

        {
            Phone product = _db.Products.FirstOrDefault(p => p.Id == productId);
            return View(new Order { Product = product });

        }

        [HttpPost]

        public IActionResult Create(Order order)

        {

            if (order != null)

            {

                _db.Orders.Add(order);

                _db.SaveChanges();

            }

            return RedirectToAction("Index");

        }
    }
}
