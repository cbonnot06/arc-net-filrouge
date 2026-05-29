using Microsoft.AspNetCore.Mvc;
using TechProShop.TechProQuote.Application.Interfaces;
using TechProShop.TechProQuote.Domain.Entities;

namespace TechProShop.TechProQuote.Web.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientRepository _repo;

        public ClientsController(IClientRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var clients = await _repo.GetAllAsync();

            return View(clients);
        }
    }
}
