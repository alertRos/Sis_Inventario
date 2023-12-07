using InventorySystem.Core.Application.Interface.Services;
using InventorySystem.Core.Application.Services;
using InventorySystem.Core.Application.ViewModel.Negocio;
using InventorySystem.Core.Domain.Entities;
using InventorySystem.Middlewares;
using InventorySystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InventorySystem.Controllers
{
    public class NegocioController : Controller
    {
        private readonly INegocioService _negocioService;
        private readonly ValidateUserSession _validateUserSession;
        private readonly IOperationStatusService _operationStatusService;

        public NegocioController(INegocioService negocioService, ValidateUserSession validateUser, IOperationStatusService operationStatus)
        {
            _negocioService = negocioService;
            _operationStatusService = operationStatus;
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
            var negocio = await _negocioService.GetByNombre(vm.Nombre);
            if (negocio == true)
            {
                ModelState.AddModelError("Nombre", "El nombre de negocio ya está registrado.");
                return View("Create", vm);
            }
            _operationStatusService.OperationSuccess = true;
            TempData["Negocio"] = JsonConvert.SerializeObject(vm);
            return RedirectToRoute(new { controller = "Usuario", action = "Create" });
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
