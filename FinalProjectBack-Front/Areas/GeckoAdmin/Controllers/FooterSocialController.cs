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
    public class FooterSocialController : Controller
    {
        private readonly AppDbContext _context;

        public FooterSocialController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.TotalPage = Math.Ceiling((decimal)_context.FooterSocials.Count() / 6);
            ViewBag.CurrentPage = page;
            List<FooterSocial> socials = _context.FooterSocials.Skip((page - 1) * 6).Take(6).ToList();
            return View(socials);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FooterSocial media)
        {
            if (!ModelState.IsValid) return View();

            FooterSocial mediaControl = _context.FooterSocials.FirstOrDefault(f => f.SocialIcon.Trim().ToLower() == media.SocialIcon && f.SocialUrl.Trim().ToLower() == media.SocialUrl.Trim().ToLower() || f.SocialIcon.Trim().ToLower() == media.SocialIcon && f.SocialUrl.Trim().ToLower() != media.SocialUrl.Trim().ToLower() || f.SocialIcon.Trim().ToLower() != media.SocialIcon && f.SocialUrl.Trim().ToLower() == media.SocialUrl.Trim().ToLower());
            if (mediaControl!=null)
            {
                ModelState.AddModelError("", "Please enter different social media url or social media icon.These are existed in database");
                return View();
            }

            _context.FooterSocials.Add(media);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            FooterSocial media = _context.FooterSocials.FirstOrDefault(f => f.Id == id);
            if (media == null) return NotFound();
            return View(media);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,FooterSocial media)
        {
            FooterSocial mediaControl = _context.FooterSocials.FirstOrDefault(f => f.SocialIcon.Trim().ToLower() == media.SocialIcon && f.SocialUrl.Trim().ToLower() == media.SocialUrl.Trim().ToLower() || f.SocialIcon.Trim().ToLower() == media.SocialIcon && f.SocialUrl.Trim().ToLower() != media.SocialUrl.Trim().ToLower() || f.SocialIcon.Trim().ToLower() != media.SocialIcon && f.SocialUrl.Trim().ToLower() == media.SocialUrl.Trim().ToLower());
            if (!ModelState.IsValid) return View();
            FooterSocial existedMedia = _context.FooterSocials.FirstOrDefault(f => f.Id == media.Id);

            if (existedMedia == null) return NotFound();

            if (mediaControl!=null && mediaControl.Id!=id)
            {
                ModelState.AddModelError("", "Please enter different social media url or social media icon.These are existed in database");
                return View(existedMedia);
            }

            existedMedia.SocialUrl = media.SocialUrl;
            existedMedia.SocialIcon = media.SocialIcon;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            FooterSocial media = _context.FooterSocials.FirstOrDefault(f => f.Id == id);
            FooterSocial existedMedia = _context.FooterSocials.FirstOrDefault(f => f.Id == media.Id);

            if (existedMedia == null) return NotFound();
            if (media == null) return Json(new { status = 404 });
            _context.FooterSocials.Remove(media);
            _context.SaveChanges();
            return Json(new { status = 200 });
        }
    }
}
