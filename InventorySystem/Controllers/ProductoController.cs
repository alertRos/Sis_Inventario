using InventorySystem.Core.Application.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoService _productService;
        public ProductoController(IProductoService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
