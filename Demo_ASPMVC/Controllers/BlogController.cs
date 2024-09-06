using Microsoft.AspNetCore.Mvc;

namespace Demo_ASPMVC.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Example(string slug)
        {
            Console.WriteLine("Blog : " + slug);
            return View();
        }
    }
}
