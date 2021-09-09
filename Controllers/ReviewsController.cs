using homework_54.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_54.Controllers
{
    public class ReviewsController : Controller
    {
        private StoreContext _db;

        public ReviewsController(StoreContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Review> reviews = _db.Reviews.ToList();
            return View(reviews);
        }
        public IActionResult Create(int Id)
        {
            Phone phone = _db.Products.FirstOrDefault(p => p.Id == Id);
            return View(new Review { Phone = phone });
        }
        [HttpPost]
        public IActionResult Create(Review review)

        {

            if (review != null)

            {
                Phone phone = _db.Products.FirstOrDefault(p => p.Id == review.Id);
                review.Phone = phone;
                _db.Reviews.Add(review);

                _db.SaveChanges();

            }


            return RedirectToAction("Index");

        }
    }
}
