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
    public class SizeController : Controller
    {
        private readonly AppDbContext _context;

        public SizeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.TotalPage = Math.Ceiling((decimal)_context.Sizes.Count() / 6);
            ViewBag.CurrentPage = page;
            List<Size> sizes = _context.Sizes.Skip((page - 1) * 6).Take(6).ToList();
            return View(sizes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Size size)
        {
            if (!ModelState.IsValid) return View();

            Size sizeControl = _context.Sizes.FirstOrDefault(s => s.Value.Trim().ToLower() == size.Value.Trim().ToLower());
            if (sizeControl != null)
            {
                ModelState.AddModelError("Value", "Please enter another size.Size you just entered is existed in database");
                return View();
            }

            _context.Sizes.Add(size);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            Size size = _context.Sizes.FirstOrDefault(s => s.Id == id);
            if (size == null) return NotFound();
            return View(size);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Size size, int id)
        {
            Size sizeControl = _context.Sizes.FirstOrDefault(s => s.Value.Trim().ToLower() == size.Value.Trim().ToLower());
            if (!ModelState.IsValid) return View();
            Size existedSize = _context.Sizes.FirstOrDefault(s => s.Id == size.Id);
            if (existedSize == null) return NotFound();
            if (sizeControl != null && sizeControl.Id != id)
            {
                ModelState.AddModelError("Value", "Please enter another size.Size you just entered is existed in database");
                return View(existedSize);
            }
            existedSize.Value = size.Value;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Size size = _context.Sizes.FirstOrDefault(s => s.Id == id);
            Size existedSize = _context.Sizes.FirstOrDefault(s => s.Id == size.Id);
            if (existedSize == null) return NotFound();
            if (size == null) return Json(new { status = 404 });
            _context.Sizes.Remove(size);
            _context.SaveChanges();
            return Json(new { status = 200 });
        }
    }
}
