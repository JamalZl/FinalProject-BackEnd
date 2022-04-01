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
    public class SettingController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SettingController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Setting> settings = _context.Settings.ToList();
            return View(settings);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Setting setting)
        {
            if (!ModelState.IsValid) return View();


            if (setting.LogoImageFile == null )
            {
                ModelState.AddModelError("LogoImageFile", "Please don't leave empty image area");
                return View();
            }
            else
            {
                if (!setting.LogoImageFile.IsImage())
                {
                    ModelState.AddModelError("LogoImageFile", "Please insert a valid image type such as jpg,png,jpeg etc");
                    return View();
                }
                if (!setting.LogoImageFile.IsSizeOkay(2))
                {
                    ModelState.AddModelError("LogoImageFile", "Image size can not be more than 2MB");
                    return View();
                }
                setting.Logo = setting.LogoImageFile.SaveImg(_env.WebRootPath, "assets/images");
            }


            if (setting.HandpickedImageFile == null)
            {
                ModelState.AddModelError("HandpickedImageFile", "Please don't leave empty image area");
                return View();
            }
            else
            {
                if (!setting.HandpickedImageFile.IsImage())
                {
                    ModelState.AddModelError("HandpickedImageFile", "Please insert a valid image type such as jpg,png,jpeg etc");
                    return View();
                }
                if (!setting.HandpickedImageFile.IsSizeOkay(2))
                {
                    ModelState.AddModelError("HandpickedImageFile", "Image size can not be more than 2MB");
                    return View();
                }
                setting.HandpickedImage = setting.HandpickedImageFile.SaveImg(_env.WebRootPath, "assets/images");
            }

            if (setting.NewArrivalImageFile == null)
            {
                ModelState.AddModelError("NewArrivalImageFile", "Please don't leave empty image area");
                return View();
            }
            else
            {
                if (!setting.NewArrivalImageFile.IsImage())
                {
                    ModelState.AddModelError("NewArrivalImageFile", "Please insert a valid image type such as jpg,png,jpeg etc");
                    return View();
                }
                if (!setting.NewArrivalImageFile.IsSizeOkay(2))
                {
                    ModelState.AddModelError("NewArrivalImageFile", "Image size can not be more than 2MB");
                    return View();
                }
                setting.NewArrivalImage = setting.NewArrivalImageFile.SaveImg(_env.WebRootPath, "assets/images");
            }

            if (setting.FunImageFile == null)
            {
                ModelState.AddModelError("FunImageFile", "Please don't leave empty image area");
                return View();
            }
            else
            {
                if (!setting.FunImageFile.IsImage())
                {
                    ModelState.AddModelError("FunImageFile", "Please insert a valid image type such as jpg,png,jpeg etc");
                    return View();
                }
                if (!setting.FunImageFile.IsSizeOkay(2))
                {
                    ModelState.AddModelError("FunImageFile", "Image size can not be more than 2MB");
                    return View();
                }
                setting.FunImage = setting.FunImageFile.SaveImg(_env.WebRootPath, "assets/images");
            }


            if (setting.SubscribeImageFile == null)
            {
                ModelState.AddModelError("SubscribeImageFile", "Please don't leave empty image area");
                return View();
            }
            else
            {
                if (!setting.SubscribeImageFile.IsImage())
                {
                    ModelState.AddModelError("SubscribeImageFile", "Please insert a valid image type such as jpg,png,jpeg etc");
                    return View();
                }
                if (!setting.SubscribeImageFile.IsSizeOkay(2))
                {
                    ModelState.AddModelError("SubscribeImageFile", "Image size can not be more than 2MB");
                    return View();
                }
                setting.SubscribeImage = setting.SubscribeImageFile.SaveImg(_env.WebRootPath, "assets/images");
            }


            if (setting.UpliftedImageFile == null)
            {
                ModelState.AddModelError("UpliftedImageFile", "Please don't leave empty image area");
                return View();
            }
            else
            {
                if (!setting.UpliftedImageFile.IsImage())
                {
                    ModelState.AddModelError("UpliftedImageFile", "Please insert a valid image type such as jpg,png,jpeg etc");
                    return View();
                }
                if (!setting.UpliftedImageFile.IsSizeOkay(2))
                {
                    ModelState.AddModelError("UpliftedImageFile", "Image size can not be more than 2MB");
                    return View();
                }
                setting.UpliftedImage = setting.UpliftedImageFile.SaveImg(_env.WebRootPath, "assets/images");
            }


            if (setting.FooterPaymentImageFile == null)
            {
                ModelState.AddModelError("FooterPaymentImageFile", "Please don't leave empty image area");
                return View();
            }
            else
            {
                if (!setting.FooterPaymentImageFile.IsImage())
                {
                    ModelState.AddModelError("FooterPaymentImageFile", "Please insert a valid image type such as jpg,png,jpeg etc");
                    return View();
                }
                if (!setting.FooterPaymentImageFile.IsSizeOkay(2))
                {
                    ModelState.AddModelError("FooterPaymentImageFile", "Image size can not be more than 2MB");
                    return View();
                }
                setting.FooterPaymentImage = setting.FooterPaymentImageFile.SaveImg(_env.WebRootPath, "assets/images");
            }
            _context.Settings.Add(setting);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            Setting setting = _context.Settings.FirstOrDefault(s => s.Id == id);
            if (setting == null) return NotFound();
            return View(setting);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Setting setting)
        {
            Setting existedSetting = _context.Settings.FirstOrDefault(s => s.Id == setting.Id);
            if (!ModelState.IsValid) return View();
            if (existedSetting == null) return NotFound();

            if (setting.LogoImageFile != null)
            {
                if (!setting.LogoImageFile.IsImage())
                {
                    ModelState.AddModelError("LogoImageFile", "Please insert a valid image type such as jpg,png,jpeg etc");
                    return View(existedSetting);
                }
                if (!setting.LogoImageFile.IsSizeOkay(2))
                {
                    ModelState.AddModelError("LogoImageFile", "Image size can not be more than 2MB");
                    return View(existedSetting);
                }
                Helpers.Helper.DeleteImg(_env.WebRootPath, "assets/images", existedSetting.Logo);
                existedSetting.Logo = setting.LogoImageFile.SaveImg(_env.WebRootPath, "assets/images");
            }

            if (setting.HandpickedImageFile != null)
            {
                if (!setting.HandpickedImageFile.IsImage())
                {
                    ModelState.AddModelError("HandpickedImageFile", "Please insert a valid image type such as jpg,png,jpeg etc");
                    return View(existedSetting);
                }
                if (!setting.HandpickedImageFile.IsSizeOkay(2))
                {
                    ModelState.AddModelError("HandpickedImageFile", "Image size can not be more than 2MB");
                    return View(existedSetting);
                }
                Helpers.Helper.DeleteImg(_env.WebRootPath, "assets/images", existedSetting.Logo);
                existedSetting.HandpickedImage = setting.HandpickedImageFile.SaveImg(_env.WebRootPath, "assets/images");
            }

            if (setting.NewArrivalImageFile != null)
            {
                if (!setting.NewArrivalImageFile.IsImage())
                {
                    ModelState.AddModelError("NewArrivalImageFile", "Please insert a valid image type such as jpg,png,jpeg etc");
                    return View(existedSetting);
                }
                if (!setting.NewArrivalImageFile.IsSizeOkay(2))
                {
                    ModelState.AddModelError("NewArrivalImageFile", "Image size can not be more than 2MB");
                    return View(existedSetting);
                }
                Helpers.Helper.DeleteImg(_env.WebRootPath, "assets/images", existedSetting.Logo);
                existedSetting.NewArrivalImage = setting.NewArrivalImageFile.SaveImg(_env.WebRootPath, "assets/images");
            }

            if (setting.FunImageFile != null)
            {
                if (!setting.FunImageFile.IsImage())
                {
                    ModelState.AddModelError("FunImageFile", "Please insert a valid image type such as jpg,png,jpeg etc");
                    return View(existedSetting);
                }
                if (!setting.FunImageFile.IsSizeOkay(2))
                {
                    ModelState.AddModelError("FunImageFile", "Image size can not be more than 2MB");
                    return View(existedSetting);
                }
                Helpers.Helper.DeleteImg(_env.WebRootPath, "assets/images", existedSetting.Logo);
                existedSetting.FunImage = setting.FunImageFile.SaveImg(_env.WebRootPath, "assets/images");
            }

            if (setting.SubscribeImageFile != null)
            {
                if (!setting.SubscribeImageFile.IsImage())
                {
                    ModelState.AddModelError("SubscribeImageFile", "Please insert a valid image type such as jpg,png,jpeg etc");
                    return View(existedSetting);
                }
                if (!setting.SubscribeImageFile.IsSizeOkay(2))
                {
                    ModelState.AddModelError("SubscribeImageFile", "Image size can not be more than 2MB");
                    return View(existedSetting);
                }
                Helpers.Helper.DeleteImg(_env.WebRootPath, "assets/images", existedSetting.Logo);
                existedSetting.SubscribeImage = setting.SubscribeImageFile.SaveImg(_env.WebRootPath, "assets/images");
            }

            if (setting.UpliftedImageFile != null)
            {
                if (!setting.UpliftedImageFile.IsImage())
                {
                    ModelState.AddModelError("UpliftedImageFile", "Please insert a valid image type such as jpg,png,jpeg etc");
                    return View(existedSetting);
                }
                if (!setting.UpliftedImageFile.IsSizeOkay(2))
                {
                    ModelState.AddModelError("UpliftedImageFile", "Image size can not be more than 2MB");
                    return View(existedSetting);
                }
                Helpers.Helper.DeleteImg(_env.WebRootPath, "assets/images", existedSetting.Logo);
                existedSetting.UpliftedImage = setting.UpliftedImageFile.SaveImg(_env.WebRootPath, "assets/images");
            }

            if (setting.FooterPaymentImageFile != null)
            {
                if (!setting.FooterPaymentImageFile.IsImage())
                {
                    ModelState.AddModelError("FooterPaymentImageFile", "Please insert a valid image type such as jpg,png,jpeg etc");
                    return View(existedSetting);
                }
                if (!setting.FooterPaymentImageFile.IsSizeOkay(2))
                {
                    ModelState.AddModelError("FooterPaymentImageFile", "Image size can not be more than 2MB");
                    return View(existedSetting);
                }
                Helpers.Helper.DeleteImg(_env.WebRootPath, "assets/images", existedSetting.Logo);
                existedSetting.FooterPaymentImage = setting.FooterPaymentImageFile.SaveImg(_env.WebRootPath, "assets/images");
            }

            existedSetting.BasketIcon = setting.BasketIcon;
            existedSetting.CloseIcon = setting.CloseIcon;
            existedSetting.FooterAddress = setting.FooterAddress;
            existedSetting.FooterAdressIcon = setting.FooterAdressIcon;
            existedSetting.FooterEmail = setting.FooterEmail;
            existedSetting.FooterEmailIcon = setting.FooterEmailIcon;
            existedSetting.FooterNumber = setting.FooterNumber;
            existedSetting.FooterNumberIcon = setting.FooterNumberIcon;
            existedSetting.HandpickedSale = setting.HandpickedSale;
            existedSetting.HandpickedSaleTitle = setting.HandpickedSaleTitle;
            existedSetting.MenuIcon = setting.MenuIcon;
            existedSetting.SearchIcon = setting.SearchIcon;
            existedSetting.SubscribeTitle = setting.SubscribeTitle;
            existedSetting.UserIcon = setting.UserIcon;
            existedSetting.WhishlistIcon = setting.WhishlistIcon;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
