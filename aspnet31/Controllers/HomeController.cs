﻿using aspnet31.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet31.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("Unauthorized/")]
        public IActionResult Unauthorized()
        {
            return View("401");
            //return StatusCode(401);
        }

        [HttpGet("Notfound/")]
        public IActionResult Notfound()
        {
            return View("404");
            //return StatusCode(404);
        }

        [HttpGet("Forbidden/")]
        public IActionResult Forbidden()
        {
            return View("403");
            //return StatusCode(403);
        }
    }
}
