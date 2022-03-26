using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBack_Front.Controllers
{
    public class WhishlistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
