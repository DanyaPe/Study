using AspNetCore;
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

        public IActionResult PlayerList(CreatePlayerViewModel model)
        {
            if (ModelState.IsValid)
            {  
                PlayerViewModel one = new PlayerViewModel();
                one.Name = model.Name;
                one.GetCards();
                Players.Add(one);
                return RedirectToAction("PlayerClient", one);
            }
            return View("PlayerCreate");
        }

        public IActionResult PlayerCreate()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}