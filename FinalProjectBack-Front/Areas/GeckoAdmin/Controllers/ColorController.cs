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
    public class ColorController : Controller
    {
        private readonly AppDbContext _context;

        public ColorController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.TotalPage = Math.Ceiling((decimal)_context.Colors.Count() / 6);
            ViewBag.CurrentPage = page;
            List<Color> colors = _context.Colors.Skip((page - 1) * 6).Take(6).ToList();
            return View(colors);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Color color)
        {
            if (!ModelState.IsValid) return View();

            Color colorControl = _context.Colors.FirstOrDefault(c => c.Name.Trim().ToLower() == color.Name.Trim().ToLower() && c.Value.Trim().ToLower()==color.Value.Trim().ToLower() || c.Name.Trim().ToLower() != color.Name.Trim().ToLower() && c.Value.Trim().ToLower() == color.Value.Trim().ToLower() || c.Name.Trim().ToLower() == color.Name.Trim().ToLower() && c.Value.Trim().ToLower() != color.Value.Trim().ToLower());
            if (colorControl != null)
            {
                ModelState.AddModelError("", "Please enter different color name or value.These are existed in database");
                return View();
            }
            _context.Colors.Add(color);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            Color color = _context.Colors.FirstOrDefault(c => c.Id == id);
            if (color == null) return NotFound();
            return View(color);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Color color,int id)
        {
            Color colorControl = _context.Colors.FirstOrDefault(c => c.Name.Trim().ToLower() == color.Name.Trim().ToLower() && c.Value.Trim().ToLower() == color.Value.Trim().ToLower() || c.Name.Trim().ToLower() != color.Name.Trim().ToLower() && c.Value.Trim().ToLower() == color.Value.Trim().ToLower() || c.Name.Trim().ToLower() == color.Name.Trim().ToLower() && c.Value.Trim().ToLower() != color.Value.Trim().ToLower());

            if (!ModelState.IsValid) return View();

            Color existedColor = _context.Colors.First(c => c.Id == color.Id);
            if (existedColor==null) return NotFound();

            if(colorControl!=null && colorControl.Id != id)
            {
                ModelState.AddModelError("", "Please enter different color name and value.These are existed in database");
                return View(existedColor);
            }
            existedColor.Name = color.Name;
            existedColor.Value = color.Value;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Color color = _context.Colors.FirstOrDefault(c => c.Id == id);
            Color existedColor = _context.Colors.FirstOrDefault(c => c.Id == color.Id);
            if (existedColor == null) return NotFound();
            if (color == null) return Json(new { status = 404 });
            _context.Colors.Remove(color);
            _context.SaveChanges();
            return Json(new { status = 200 });
        }
    }
}
