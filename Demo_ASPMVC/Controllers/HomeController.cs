using Demo_ASPMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Demo_ASPMVC.Controllers
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
            Console.WriteLine("Start Index !");
            long test = 1;
            for (long i = 0; i < 1_000_000; i++)
            {
                test += 1;
            }
            Console.WriteLine("Finish : " + test);

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
    }
}
