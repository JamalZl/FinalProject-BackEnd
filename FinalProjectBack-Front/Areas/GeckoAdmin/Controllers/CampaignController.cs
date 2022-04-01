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
    public class CampaignController : Controller
    {
        private readonly AppDbContext _context;

        public CampaignController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.TotalPage = Math.Ceiling((decimal)_context.Campaigns.Count() / 6);
            ViewBag.CurrentPage = page;
            List<Campaign> campaigns = _context.Campaigns.Skip((page - 1) * 6).Take(6).ToList();
            return View(campaigns);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Campaign campaign)
        {
            if (!ModelState.IsValid) return View();

            Campaign categoryControl = _context.Campaigns.FirstOrDefault(s => s.DiscountPercent.ToString().Trim()==campaign.DiscountPercent.ToString().Trim());
            if (campaign.DiscountPercent>=100)
            {
                ModelState.AddModelError("DiscountPercent","Discount percent can not be more than 100%");
                return View();
            }
            if (categoryControl != null)
            {
                ModelState.AddModelError("DiscountPercent", "Please enter another discount percent.Discount percent you just entered is existed in database");
                return View();
            }
            _context.Campaigns.Add(campaign);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            Campaign campaign = _context.Campaigns.FirstOrDefault(c => c.Id == id);
            if (campaign == null) return NotFound();
            return View(campaign);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Campaign campaign)
        {
            Campaign existedCampaign = _context.Campaigns.FirstOrDefault(c => c.Id == campaign.Id);
            Campaign categoryControl = _context.Campaigns.FirstOrDefault(s => s.DiscountPercent.ToString().Trim() == campaign.DiscountPercent.ToString().Trim());
            if (existedCampaign == null) return NotFound();
            if (campaign.DiscountPercent >= 100)
            {
                ModelState.AddModelError("DiscountPercent", "Discount percent can not be more than 100%");
                return View(existedCampaign);
            }
            if (categoryControl != null && categoryControl.Id!=id)
            {
                ModelState.AddModelError("DiscountPercent", "Please enter another discount percent.Discount percent you just entered is existed in database");
                return View(existedCampaign);
            }
            existedCampaign.DiscountPercent = campaign.DiscountPercent;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Delete(int id)
        {
            Campaign campaign = _context.Campaigns.FirstOrDefault(c => c.Id == id);
            Campaign existedCampaign = _context.Campaigns.FirstOrDefault(c => c.Id == campaign.Id);
            if (existedCampaign == null) return NotFound();
            if (campaign == null) return Json(new { status = 404 });
            _context.Campaigns.Remove(campaign);
            _context.SaveChanges();
            return Json(new { status = 200 });
        }
    }
}
