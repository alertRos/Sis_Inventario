using InventorySystem.Core.Application.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Controllers
{
    public class ProveedorController : Controller
    {
        private readonly IProveedorService _proveedorService;
        public ProveedorController(IProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
