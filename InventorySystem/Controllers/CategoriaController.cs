using InventorySystem.Core.Application.Interface.Services;
using InventorySystem.Core.Application.ViewModel.Categoria;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoriaController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _categoryService.GetAllViewModel());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoriaSaveViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            await _categoryService.Add(vm);
            return RedirectToRoute(new { controller = "Categoria", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var vm = await _categoryService.GetById(id);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoriaSaveViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            await _categoryService.Update(vm);
            return RedirectToRoute(new { controller = "Categoria", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View("Delete", await _categoryService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _categoryService.Delete(id);
            return RedirectToRoute(new { controller = "Categoria", action = "Index" });
        }
    }
}
