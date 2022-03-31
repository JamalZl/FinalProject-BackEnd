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
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.TotalPage = Math.Ceiling((decimal)_context.Sliders.Count() / 3);
            ViewBag.CurrentPage = page;
            List<Slider> sliders = _context.Sliders.Skip((page - 1) * 3).Take(3).ToList();
            return View(sliders);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Slider slider)
        {
            if (!ModelState.IsValid) return View();

            if (slider.ImageFile==null)
            {
                ModelState.AddModelError("ImageFile", "Please insert an image");
                return View();
            }
            else
            {
                if (!slider.ImageFile.IsImage())
                {
                    ModelState.AddModelError("ImageFile", "Please insert a valid image type such as jpg,png,jpeg etc");
                    return View();
                }
                if (!slider.ImageFile.IsSizeOkay(2))
                {
                    ModelState.AddModelError("ImageFile", "Image size can not be more than 2MB");
                    return View();
                }

                slider.Image = slider.ImageFile.SaveImg(_env.WebRootPath, "assets/images");
            }

            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public  IActionResult Edit(int id)
        {
            Slider slider = _context.Sliders.FirstOrDefault(s => s.Id == id);
            if (slider == null) return NotFound();
            return View(slider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Slider slider)
        {
            if (!ModelState.IsValid) return View();
            Slider existedSlider = _context.Sliders.FirstOrDefault(s => s.Id == slider.Id);
            if (existedSlider == null) return NotFound();
            if (slider.ImageFile!=null)
            {
                if (!slider.ImageFile.IsImage())
                {
                    ModelState.AddModelError("ImageFile", "Please insert a valid image type such as jpg,png,jpeg etc");
                    return View(existedSlider);
                }
                if (!slider.ImageFile.IsSizeOkay(2))
                {
                    ModelState.AddModelError("ImageFile", "Image size can not be more than 2MB");
                    return View(existedSlider);
                }

                Helpers.Helper.DeleteImg(_env.WebRootPath, "assets/images", existedSlider.Image);
                existedSlider.Image = slider.ImageFile.SaveImg(_env.WebRootPath, "assets/images");
            }

            existedSlider.Title = slider.Title;
            existedSlider.Description = slider.Description;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Slider slider = _context.Sliders.FirstOrDefault(c => c.Id == id);
            Slider existedSlider = _context.Sliders.FirstOrDefault(c => c.Id == slider.Id);
            if (existedSlider == null) return NotFound();
            if (slider == null) return Json(new { status = 404 });
            _context.Sliders.Remove(slider);
            _context.SaveChanges();
            return Json(new { status = 200 });
        }
    }
}
