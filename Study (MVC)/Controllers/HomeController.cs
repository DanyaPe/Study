using Microsoft.AspNetCore.Mvc;
using Study__MVC_.Models;
using System.Diagnostics;

namespace Study__MVC_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public static List<Player> Players = new();

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

        public IActionResult Player(CreatePlayerViewModel model)
        {
            if (ModelState.IsValid)
            {  
                Player one = new Player();
                one.Name = model.Name;
                Players.Add(one);
                return View(Players);
            }
            return RedirectToAction("PlayerCreate");
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