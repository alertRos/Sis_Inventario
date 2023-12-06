using InventorySystem.Core.Application.Interface.Services;
using InventorySystem.Core.Application.ViewModel.Marca;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Controllers
{
    public class MarcaController : Controller
    {
        private readonly IMarcaService _marcaService;
        public MarcaController(IMarcaService marcaService)
        {
            _marcaService = marcaService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _marcaService.GetAllViewModel());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MarcaSaveViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            await _marcaService.Add(vm);
            return RedirectToRoute(new { controller = "Marca", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var vm = await _marcaService.GetById(id);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MarcaSaveViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            await _marcaService.Update(vm);
            return RedirectToRoute(new { controller = "Marca", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View("Delete",await _marcaService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _marcaService.Delete(id);
            return RedirectToRoute(new { controller = "Marca", action = "Index" });
        }

    }
}
