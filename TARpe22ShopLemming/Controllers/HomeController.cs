﻿using Microsoft.AspNetCore.Mvc;

namespace TARpe22ShopLemming.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
