using InventorySystem.Core.Application.Interface.Services;
using InventorySystem.Core.Application.ViewModel.Proveedor;
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
        public async Task<IActionResult> Index()
        {
            return View(await _proveedorService.GetAllViewModel());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProveedorSaveViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            await _proveedorService.Add(vm);
            return RedirectToRoute(new { controller = "Proveedor", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var vm = await _proveedorService.GetById(id);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProveedorSaveViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            await _proveedorService.Update(vm);
            return RedirectToRoute(new { controller = "Proveedor", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View("Delete", await _proveedorService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _proveedorService.Delete(id);
            return RedirectToRoute(new { controller = "Proveedor", action = "Index" });
        }
    }
}
