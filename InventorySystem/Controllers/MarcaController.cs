using InventorySystem.Core.Application.Interface.Services;
using InventorySystem.Core.Application.ViewModel.Marca;
using InventorySystem.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Controllers
{
    public class MarcaController : Controller
    {
        private readonly IMarcaService _marcaService;
        private readonly ValidateUserSession _validateUserSession;
        public MarcaController(IMarcaService marcaService, ValidateUserSession validateUserSession)
        {
            _marcaService = marcaService;
            _validateUserSession = validateUserSession;
        }
        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            return View(await _marcaService.GetAllViewModel());
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
            MarcaSaveViewModel vm = new();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MarcaSaveViewModel vm)
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
            await _marcaService.Add(vm);
            return RedirectToRoute(new { controller = "Marca", action = "Index" });
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
            var vm = await _marcaService.GetById(id);
            return View("Create",vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MarcaSaveViewModel vm)
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
                return View("Create",vm);
            }
            await _marcaService.Update(vm);
            return RedirectToRoute(new { controller = "Marca", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!_validateUserSession.hasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            }
            await _marcaService.Delete(id);
            return RedirectToRoute(new { controller = "Marca", action = "Index" });
        }

    }
}
