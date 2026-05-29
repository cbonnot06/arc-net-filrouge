using Microsoft.AspNetCore.Mvc;

namespace TechProShop.TechProQuote.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
