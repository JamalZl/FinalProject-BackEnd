using FinalProjectBack_Front.DAL;
using FinalProjectBack_Front.Extensions;
using FinalProjectBack_Front.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBack_Front.Areas.GeckoAdmin.Controllers
{
    [Area("GeckoAdmin")]
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ContactController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Contact> contact = _context.Contacts.ToList();
            return View(contact);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Contact contact)
        {
            if (!ModelState.IsValid) return View();

            if (contact.ImageFile==null)
            {
                ModelState.AddModelError("ImageFile", "Please insert an image");
                return View();
            }
            else
            {
                if (!contact.ImageFile.IsImage())
                {
                    ModelState.AddModelError("ImageFile", "Please insert a valid image type such as jpg,png,jpeg etc");
                    return View();
                }
                if (!contact.ImageFile.IsSizeOkay(2))
                {
                    ModelState.AddModelError("ImageFile", "Image size can not be more than 2MB");
                    return View();
                }
                contact.Image = contact.ImageFile.SaveImg(_env.WebRootPath, "assets/images");
            }

            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            Contact contact = _context.Contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null) return NotFound();
            return View(contact);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Contact contact)
        {
            if (!ModelState.IsValid) return View();
            Contact existedContact = _context.Contacts.FirstOrDefault(c => c.Id == contact.Id);
            if (existedContact == null) return NotFound();
            if (contact.ImageFile!=null)
            {
                if (!contact.ImageFile.IsImage())
                {
                    ModelState.AddModelError("ImageFile", "Please insert a valid image type such as jpg,png,jpeg etc");
                    return View();
                }
                if (!contact.ImageFile.IsSizeOkay(2))
                {
                    ModelState.AddModelError("ImageFile", "Image size can not be more than 2MB");
                    return View();
                }
                Helpers.Helper.DeleteImg(_env.WebRootPath, "assets/images", existedContact.Image);
                existedContact.Image = contact.ImageFile.SaveImg(_env.WebRootPath, "assets/images");
            }
            existedContact.Description = contact.Description;
            existedContact.Email = contact.Email;
            existedContact.Address = contact.Address;
            existedContact.WorkingHours = contact.WorkingHours;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
