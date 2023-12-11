using InventorySystem.Core.Application.Interface.Services;
using InventorySystem.Middlewares;
using InventorySystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InventorySystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ValidateUserSession _validateUserSession;
        private readonly IProductoService _service;
        public HomeController(ILogger<HomeController> logger, ValidateUserSession validateUserSession, IProductoService service)
        {
            _logger = logger;
            _validateUserSession = validateUserSession;
            _service = service;
        }



        public IActionResult Index()
        {
   

            return View();
        }

        public async Task<IActionResult> Dashboard()
        {
            if (!_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Login" });
            }

            return View(await _service.SumarStock());
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