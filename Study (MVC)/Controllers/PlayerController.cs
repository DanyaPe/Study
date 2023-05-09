using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Study__MVC_.Models;
using System.Diagnostics;

namespace Study__MVC_.Controllers
{
    public class PlayerController: Controller
    {
        public static List<PlayerViewModel> Players = new();

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
    }
}
