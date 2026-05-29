using Microsoft.AspNetCore.Mvc;
using TechProShop.TechProQuote.Domain.Entities;

namespace TechProShop.TechProQuote.Web.Controllers
{
    public class ClientsController : Controller
    {
        public IActionResult Index()
        {
            var clients = new List<Client> 
            { 
                new Client { Nom = "Alice Martin", Email = "alice@ex.com" }, 
                new Client { Nom = "Bob Durand", Email = "bob@ex.com" } 
            }; 

            return View(clients);
        }
    }
}
