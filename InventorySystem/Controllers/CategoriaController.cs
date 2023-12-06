using InventorySystem.Core.Application.Interface.Services;
using InventorySystem.Core.Application.ViewModel.Categoria;
using InventorySystem.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ValidateUserSession _validateUserSession;
        public CategoriaController(ICategoryService categoryService, ValidateUserSession validateUserSession)
        {
            _categoryService = categoryService;
            _validateUserSession = validateUserSession;
        }
        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View(await _categoryService.GetAllViewModel());
        }

        public IActionResult Create()
        {
            if (!_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!_validateUserSession.hasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoriaSaveViewModel vm)
        {
            if (!_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!_validateUserSession.hasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            await _categoryService.Add(vm);
            return RedirectToRoute(new { controller = "Categoria", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!_validateUserSession.hasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            }
            var vm = await _categoryService.GetById(id);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoriaSaveViewModel vm)
        {
            if (!_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!_validateUserSession.hasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            }
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
            if (!_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!_validateUserSession.hasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            }
            await _categoryService.Delete(id);
            return RedirectToRoute(new { controller = "Categoria", action = "Index" });
        }
    }
}
