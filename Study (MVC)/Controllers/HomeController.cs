﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Study__MVC_.Models;
using System.Diagnostics;

namespace Study__MVC_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public static List<PlayerViewModel> Players = new();

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

        [HttpPost]
        public IActionResult PlayerCreate(CreatePlayerViewModel model)
        {
            if (ModelState.IsValid)
            {
                PlayerViewModel one = new PlayerViewModel();
                one.Name = model.Name;
                one.GetCards();
                Players.Add(one);
                return View("PlayerClient", one);
            }
            else
            {
                return View("PlayerCreate");
            }
        }

        [HttpGet]
        public IActionResult PlayerCreate()
        {
            return View();
        }

        public IActionResult PlayerList()
        {
            ViewBag.PL = Players;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}