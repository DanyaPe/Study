using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study__MVC_.Models;
using System.Diagnostics;

namespace Study__MVC_.Controllers
{
    public class PlayerController: Controller
    {
        ApplicationContext db;
        public PlayerController(ApplicationContext context)
        {
            db = context;
        }

        [HttpPost]
        public async Task<IActionResult> PlayerCreate(PlayerViewModel model)
        {
            if (ModelState.IsValid)
            {
                PlayerViewModel one = new PlayerViewModel();
                one.Name = model.Name;
                //one.GetCards();
                one.sys_status = 0;
                db.player.Add(one);
                db.SaveChangesAsync();
                return RedirectToAction("PlayerList", db.player);
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

        public async Task<IActionResult> PlayerList()
        {
            //ViewBag.PL = Players;
            return View(await db.player.ToListAsync());
        }
    }
}
