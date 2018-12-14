
using Microsoft.AspNetCore.Mvc;


namespace EntityFrameworkBasics.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
