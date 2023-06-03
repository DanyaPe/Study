using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study__MVC_.Models;
using System.Diagnostics;
using System.Net;
using System.Security.Claims;

namespace Study__MVC_.Controllers
{
    // Версия с БД
    /*
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
                one.sys_status = 0;
                //one.CookieUrl = model.CookieUrl;
                
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

        //[Authorize]
        public async Task<IActionResult> PlayerList()
        {
            return View(await db.player.ToListAsync());
        }
    }
    */

    // Версия со статической переменной 

    public class PlayerController : Controller
    {

        public static List<PlayerViewModel> PL = new List<PlayerViewModel>();

        [HttpPost]
        public async Task<IActionResult> PlayerCreate(PlayerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var claims = new List<Claim>
                {
                    new Claim("Demo", "Value")
                };
                var claimIdentity = new ClaimsIdentity(claims, "Cookies");
                var claimPrincipal = new ClaimsPrincipal(claimIdentity);
                await HttpContext.SignInAsync("Cookies", claimPrincipal);

                PlayerViewModel one = new PlayerViewModel();
                one.Name = model.Name;
                one.sys_status = 0;
                one.ReturnUrl = model.ReturnUrl;
                PL.Add(one);

                return Redirect(model.ReturnUrl);

            }
            
            else
            {
                return View("PlayerCreate");
            }
        }

        [HttpGet]
        public IActionResult PlayerCreate(string returnUrl)
        {
            return View();
        }

        [Authorize]
        public IActionResult PlayerListStatic()
        {
            return View(PL);
        }

    }
}
