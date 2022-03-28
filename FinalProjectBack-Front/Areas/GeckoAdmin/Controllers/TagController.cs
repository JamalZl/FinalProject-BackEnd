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
    public class TagController : Controller
    {
        private readonly AppDbContext _context;

        public TagController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.TotalPage = Math.Ceiling((decimal)_context.Tags.Count() / 6);
            ViewBag.CurrentPage = page;
            List<Tag> tags = _context.Tags.Skip((page - 1) * 6).Take(6).ToList();
            return View(tags);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tag tag)
        {
            if (!ModelState.IsValid) return View();
            Tag tagControl = _context.Tags.FirstOrDefault(t => t.Name.Trim().ToLower() == tag.Name.Trim().ToLower());
            if (tagControl!=null)
            {
                ModelState.AddModelError("Name", "Please enter another tag.Tag you just entered is existed in database");
                return View();
            }
            _context.Tags.Add(tag);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            Tag tag = _context.Tags.FirstOrDefault(t => t.Id == id);
            if (tag == null) return NotFound();
            return View(tag);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Tag tag)
        {
            Tag tagControl = _context.Tags.FirstOrDefault(t => t.Name.Trim().ToLower() == tag.Name.Trim().ToLower());
            if (!ModelState.IsValid) return View();
            Tag existedTag = _context.Tags.FirstOrDefault(t => t.Id == tag.Id);

            if (existedTag == null) return NotFound();
            if (tagControl != null && tagControl.Id!=id)
            {
                ModelState.AddModelError("Name", "Please enter another tag.Tag you just entered is existed in database");
                return View(existedTag);
            }
            existedTag.Name = tag.Name;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            Tag tag = _context.Tags.FirstOrDefault(t => t.Id == id);
            Tag existedTag = _context.Tags.FirstOrDefault(t => t.Id == tag.Id);
            if (existedTag == null) return NotFound();
            if (tag == null) return Json(new { status = 404 });
            _context.Tags.Remove(tag);
            _context.SaveChanges();
            return Json(new { status = 200 });
        }
    }
}
