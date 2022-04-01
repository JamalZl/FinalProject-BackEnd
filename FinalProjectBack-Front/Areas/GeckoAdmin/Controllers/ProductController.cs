using FinalProjectBack_Front.DAL;
using FinalProjectBack_Front.Extensions;
using FinalProjectBack_Front.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBack_Front.Areas.GeckoAdmin.Controllers
{
    [Area("GeckoAdmin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.TotalPage = Math.Ceiling((decimal)_context.Products.Count() / 6);
            ViewBag.CurrentPage = page;
            List<Product> products = _context.Products.Include(p => p.ProductImages).Skip((page - 1) * 6).Take(6).ToList();
            return View(products);
        }
        public IActionResult Create()
        {
            ViewBag.Campaigns = _context.Campaigns.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Colors = _context.Colors.ToList();
            ViewBag.Sizes = _context.Sizes.ToList();
            ViewBag.Brands = _context.Brands.ToList();
            ViewBag.Tags = _context.Tags.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            ViewBag.Campaigns = _context.Campaigns.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Colors = _context.Colors.ToList();
            ViewBag.Sizes = _context.Sizes.ToList();
            ViewBag.Brands = _context.Brands.ToList();
            ViewBag.Tags = _context.Tags.ToList();
            if (!ModelState.IsValid) return View();
            if (product.CampaignId == 0)
            {
                product.CampaignId = null;
            }
            product.ProductCategories = new List<ProductCategory>();
            product.ProductColors = new List<ProductColor>();
            product.ProductSizes = new List<ProductSize>();
            product.ProductImages = new List<ProductImage>();

            foreach (var id in product.CategoryIds)
            {
                ProductCategory pCategory = new ProductCategory
                {
                    Product = product,
                    CategoryId = id
                };
                product.ProductCategories.Add(pCategory);
            }
            foreach (var id in product.ColorIds)
            {
                ProductColor pColor = new ProductColor
                {
                    Product = product,
                    ColorId = id
                };
            }
            foreach (var id in product.SizeIds)
            {
                ProductSize pSize = new ProductSize
                {
                    Product = product,
                    SizeId = id
                };
            }
            if (product.ImageFiles.Count <= 4)
            {
                ModelState.AddModelError("ImageFiles", "You can not choose lower than 4 images");
                return View();
            }
            foreach (var img in product.ImageFiles)
            {
                if (!img.IsImage())
                {
                    ModelState.AddModelError("ImageFiles", "Please insert a valid image type such as jpg,png,jpeg etc");
                    return View();
                }
                if (!img.IsSizeOkay(2))
                {
                    ModelState.AddModelError("ImageFiles", "Image size can not be more than 2MB");
                    return View();
                }
            }
            foreach (var img in product.ImageFiles)
            {
                ProductImage pImage = new ProductImage
                {
                    Image = img.SaveImg(_env.WebRootPath, "assets/images"),
                    Product = product
                };
                product.ProductImages.Add(pImage);
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
