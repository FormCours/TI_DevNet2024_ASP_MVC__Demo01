using Demo_ASPMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo_ASPMVC.Controllers
{
    public class DemoController : Controller
    {
        private static List<PersonViewModel> people = [
            new PersonViewModel { Firstname = "Della", Lastname = "Duck" },
            new PersonViewModel { Firstname = "Zaza", Lastname = "Vanderquack" },
            new PersonViewModel { Firstname = "Gontran", Lastname = "Bonheur" },
        ];

        public IActionResult Index()
        {
            // Object "ViewData" pour partager des données entre la view et le controller
            ViewData["date"] = DateTime.Today;
            ViewData["nb"] = 42;
            ViewData["message"] = "<script>alert('Boum !')</script>";

            // Génération de la vue
            return View(people);
        }

        public IActionResult OldRoute()
        {
            TempData["MoveIt"] = true;

            return RedirectToActionPermanent(nameof(CurrentRoute));
        }


        public IActionResult CurrentRoute()
        {
            ViewData["now"] = DateTime.Now;
            return View();
        }
    }
}
