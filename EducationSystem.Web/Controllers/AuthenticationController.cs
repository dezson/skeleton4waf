using Microsoft.AspNetCore.Mvc;
using EducationSystem.Web.Models;
using EducationSystem.DataAccess.Models;
using Microsoft.AspNetCore.Http;

namespace EducationSystem.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly EducationSystemContext _context;
        private readonly IAccountService _accountService;

        public AuthenticationController(EducationSystemContext context, IAccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel user)
        {
            if (!ModelState.IsValid)
                return View("Login", user);

            // bejelentkeztetjük a felhasználót
            if (!_accountService.Login(user))
            {
                // nem szeretnénk, ha a felhasználó tudná, hogy a felhasználónévvel, vagy a jelszóval van-e baj, így csak általános hibát jelzünk
                ModelState.AddModelError("", "Hibás felhasználónév, vagy jelszó.");
                return View("Login", user);
            }

            // ha sikeres volt az ellenőrzés
            //HttpContext.Session.SetString("user", user.UserName); // felvesszük a felhasználó nevét a munkamenetbe 
            TempData["username"] = user.UserName;
            return RedirectToAction("Index", "Home"); // átirányítjuk a főoldalra
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegistrationViewModel guest)
        {
            // végrehajtjuk az ellenőrzéseket
            if (!ModelState.IsValid)
                return View("Register", guest);

            if (!_accountService.Register(guest))
            {
                ModelState.AddModelError("UserName", "A megadott felhasználónév már létezik.");
                return View("Register", guest);
            }

            ViewBag.Information = "A regisztráció sikeres volt. Kérjük, jelentkezzen be.";

            if (HttpContext.Session.GetString("user") != null) // ha be volt jelentkezve egy felhasználó, akkor kijelentkeztetjük
                HttpContext.Session.Remove("user");

            return RedirectToAction("Login");
        }
    }
}