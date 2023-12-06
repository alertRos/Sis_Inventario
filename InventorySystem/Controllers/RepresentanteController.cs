using InventorySystem.Core.Application.Interface.Services;
using InventorySystem.Core.Application.ViewModel.Categoria;
using InventorySystem.Core.Application.ViewModel.Representante;
using InventorySystem.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Controllers
{
    public class RepresentanteController : Controller
    {
        private readonly IRepresentanteService _representanteService;
        private readonly IUsuarioService _usuarioService;
        private readonly ValidateUserSession _validateUserSession;
        public RepresentanteController(IRepresentanteService representanteService, IUsuarioService usuarioService, ValidateUserSession validateUser)
        {
            _representanteService = representanteService;
            _usuarioService = usuarioService;
            _validateUserSession = validateUser;
        }
        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View(await _representanteService.GetAllViewModel());
        }

        public async Task<IActionResult> Register()
        {
            if (_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if(!_validateUserSession.hasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            RepresentanteSaveViewModel vm = new();
            vm.usuarioViewModels = await _usuarioService.GetAllViewModel();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RepresentanteSaveViewModel vm)
        {
            if (_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!_validateUserSession.hasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                vm.usuarioViewModels = await _usuarioService.GetAllViewModel();
                return View(vm);
            }
            await _representanteService.Add(vm);
            return RedirectToRoute(new { controller = "Representante", action = "Index" });
        }

        public async Task<IActionResult> Create(int idNegocio, int idUsuario)
        {
            if (_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            RepresentanteSaveViewModel vm = new();
            vm.usuarioViewModels = await _usuarioService.GetAllViewModel();
            vm.IdNegocio = idNegocio;
            vm.IdUsuario = idUsuario;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RepresentanteSaveViewModel vm)
        {
            if (_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                vm.usuarioViewModels = await _usuarioService.GetAllViewModel();
                return View(vm);
            }
            await _representanteService.Add(vm);
            return RedirectToRoute(new { controller = "Usuario", action = "Login" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!_validateUserSession.hasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            var vm = await _representanteService.GetById(id);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RepresentanteSaveViewModel vm)
        {
            if (_validateUserSession.hasUser())
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
            await _representanteService.Update(vm);
            return RedirectToRoute(new { controller = "Representante", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!_validateUserSession.hasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View("Delete", await _representanteService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!_validateUserSession.hasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            await _representanteService.Delete(id);
            return RedirectToRoute(new { controller = "Representante", action = "Index" });
        }
    }
}
