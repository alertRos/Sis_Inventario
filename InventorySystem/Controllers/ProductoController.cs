using InventorySystem.Core.Application.Interface.Services;
using InventorySystem.Core.Application.Services;
using InventorySystem.Core.Application.ViewModel.Marca;
using InventorySystem.Core.Application.ViewModel.Producto;
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
        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetAllViewModel());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductoSaveViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            await _productService.Add(vm);
            return RedirectToRoute(new { controller = "Producto", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var vm = await _productService.GetById(id);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductoSaveViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            await _productService.Update(vm);
            return RedirectToRoute(new { controller = "Producto", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View("Delete", await _productService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _productService.Delete(id);
            return RedirectToRoute(new { controller = "Marca", action = "Index" });
        }

    }
}
