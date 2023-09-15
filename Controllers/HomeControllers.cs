
using Microsoft.AspNetCore.Mvc;

namespace Advanced.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }
        public IActionResult Index() {
            return View();
        }
    }
    
}