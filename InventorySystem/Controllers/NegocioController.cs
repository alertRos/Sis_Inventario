using InventorySystem.Core.Application.Interface.Services;
using InventorySystem.Core.Application.ViewModel.Negocio;
using InventorySystem.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Controllers
{
    public class NegocioController : Controller
    {
        private readonly INegocioService _negocioService;
        private readonly ValidateUserSession _validateUserSession;
        public NegocioController(INegocioService negocioService, ValidateUserSession validateUser)
        {
            _negocioService = negocioService;
            _validateUserSession = validateUser;
        }
        public async Task<IActionResult> Index()
        {
            //Arreglar el redirect
            if (!_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!_validateUserSession.SuperUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            var result = await _negocioService.GetAllViewModel();
            return View(result);
        }
        public IActionResult Create()
        {
            if (_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NegocioSaveViewModel vm)
        {
            if (_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var negocio = await _negocioService.Add(vm);
            return RedirectToRoute(new { controller = "Usuario", action = "Create", idNegocio =negocio.Id });
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (!_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!_validateUserSession.SuperUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            var result = await _negocioService.GetById(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(NegocioSaveViewModel vm)
        {
            if (!_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!_validateUserSession.SuperUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var result = await _negocioService.Update(vm);
            return RedirectToAction("Index");
        }   

        public async Task<IActionResult> Details(int id)
        {
            if (!_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!_validateUserSession.SuperUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            var result = await _negocioService.GetById(id);
            return View(result);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!_validateUserSession.SuperUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            var result = await _negocioService.GetById(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!_validateUserSession.SuperUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            var result = await _negocioService.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
