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
    public class BrandController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public BrandController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.TotalPage = Math.Ceiling((decimal)_context.Brands.Count() / 5);
            ViewBag.CurrentPage = page;
            List<Brand> brands = _context.Brands.Skip((page - 1) * 5).Take(5).ToList();
            return View(brands);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Brand brand)
        {
            if (!ModelState.IsValid) return View();

            Brand brandControl = _context.Brands.FirstOrDefault(b => b.Name.Trim().ToLower() == brand.Name.Trim().ToLower());

            if (brandControl != null)
            {
                ModelState.AddModelError("Name", "Please enter different brand.Brand you just entered is existed in database");
                return View();
            }

            if (brand.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Please insert an image");
                return View();
            }
            else
            {
                if (!brand.ImageFile.IsImage())
                {
                    ModelState.AddModelError("ImageFile", "Please insert a valid image type such as jpg,png,jpeg etc");
                    return View();
                }
                if (!brand.ImageFile.IsSizeOkay(2))
                {
                    ModelState.AddModelError("ImageFile", "Image size can not be more than 2MB");
                    return View();
                }
                brand.Image = brand.ImageFile.SaveImg(_env.WebRootPath, "assets/images");
            }
            _context.Brands.Add(brand);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            Brand brand = _context.Brands.FirstOrDefault(b => b.Id == id);
            if (brand == null) return NotFound();
            return View(brand);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Brand brand)
        {
            if (!ModelState.IsValid) return View();
            Brand brandControl = _context.Brands.FirstOrDefault(b => b.Name.Trim().ToLower() == brand.Name.Trim().ToLower());
            Brand existedBrand = _context.Brands.FirstOrDefault(b => b.Id == brand.Id);
            if (existedBrand == null) return NotFound();
            if (brandControl != null && brandControl.Id != id)
            {
                ModelState.AddModelError("Name", "Please enter different brand.Brand you just entered is existed in database");
                return View(existedBrand);
            }
            if(brand.ImageFile!=null)
            {
                if (!brand.ImageFile.IsImage())
                {
                    ModelState.AddModelError("ImageFile", "Please insert a valid image type such as jpg,png,jpeg etc");
                    return View(existedBrand);
                }
                if (!brand.ImageFile.IsSizeOkay(2))
                {
                    ModelState.AddModelError("ImageFile", "Image size can not be more than 2MB");
                    return View(existedBrand);
                }
                Helpers.Helper.DeleteImg(_env.WebRootPath, "assets/images", existedBrand.Image);
                existedBrand.Image = brand.ImageFile.SaveImg(_env.WebRootPath, "assets/images");
            }
            existedBrand.Name = brand.Name;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Delete(int id)
        {
            Brand brand = _context.Brands.FirstOrDefault(c => c.Id == id);
            Brand existedBrand = _context.Brands.FirstOrDefault(c => c.Id == brand.Id);
            if (existedBrand == null) return NotFound();
            if (brand == null) return Json(new { status = 404 });
            _context.Brands.Remove(brand);
            _context.SaveChanges();
            return Json(new { status = 200 });
        }
    }
}
