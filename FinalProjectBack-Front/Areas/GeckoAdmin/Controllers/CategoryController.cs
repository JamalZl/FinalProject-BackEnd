using FinalProjectBack_Front.DAL;
using FinalProjectBack_Front.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBack_Front.Areas.GeckoAdmin.Controllers
{
    [Area("GeckoAdmin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.TotalPage = Math.Ceiling((decimal)_context.Categories.Count() / 6);
            ViewBag.CurrentPage = page;
            List<Category> categories = _context.Categories.Skip((page - 1) * 6).Take(6).ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid) return View();

            Category categoryControl = _context.Categories.FirstOrDefault(s => s.Name.Trim().ToLower() == category.Name.Trim().ToLower());
            if (categoryControl != null)
            {
                ModelState.AddModelError("Name", "Please enter another category.Category you just entered is existed in database");
                return View();
            }

            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            Category category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Category category)
        {
            Category categoryControl = _context.Categories.FirstOrDefault(s => s.Name.Trim().ToLower() == category.Name.Trim().ToLower());
            if (!ModelState.IsValid) return View();
            Category existedCategory = _context.Categories.FirstOrDefault(s => s.Id == category.Id);
            if (existedCategory == null) return NotFound();
            if (categoryControl != null && categoryControl.Id != id)
            {
                ModelState.AddModelError("Value", "Please enter another category.Category you just entered is existed in database");
                return View(existedCategory);
            }
            existedCategory.Name = category.Name;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Category category = _context.Categories.FirstOrDefault(c => c.Id == id);
            Category existedCategory = _context.Categories.FirstOrDefault(c => c.Id == category.Id);
            if (existedCategory == null) return NotFound();
            if (category == null) return Json(new { status = 404 });
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return Json(new { status = 200 });
        }
    }
}
