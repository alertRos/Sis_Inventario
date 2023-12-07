using InventorySystem.Core.Application.Interface.Services;
using InventorySystem.Core.Application.ViewModel.Categoria;
using InventorySystem.Core.Application.ViewModel.Negocio;
using InventorySystem.Core.Application.ViewModel.Representante;
using InventorySystem.Core.Application.ViewModel.Usuario;
using InventorySystem.Middlewares;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InventorySystem.Controllers
{
    public class RepresentanteController : Controller
    {
        private readonly IRepresentanteService _representanteService;
        private readonly IUsuarioService _usuarioService;
        private readonly INegocioService _negocioService;
        private readonly ValidateUserSession _validateUserSession;
        public RepresentanteController(INegocioService negocio,IRepresentanteService representanteService, IUsuarioService usuarioService, ValidateUserSession validateUser)
        {
            _representanteService = representanteService;
            _negocioService = negocio;
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
        

        public async Task<IActionResult> Create()
        {
            if (_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            RepresentanteSaveViewModel vm = new();
            if (TempData["Usuario"] is string usuarioJson)
            {
                // Deserializar el JSON a un objeto NegocioSaveViewModel
                var user = JsonConvert.DeserializeObject<UsuarioSaveViewModel>(usuarioJson);


                vm.usuario = user;
                if (TempData["Negocio"] is string negocioJson)
                {
                    // Deserializar el JSON a un objeto NegocioSaveViewModel
                    var negocioVm = JsonConvert.DeserializeObject<NegocioSaveViewModel>(negocioJson);
                    vm.negocio = negocioVm;
                }
                var negocio = await _negocioService.Add(vm.negocio);
                var usuario = await _usuarioService.Add(vm.usuario);
                vm.IdNegocio = negocio.Id;
                vm.IdUsuario = usuario.Id;
                vm.usuarioViewModels = await _usuarioService.GetAllViewModel();
            }

            return View(vm);
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
            var representante = await _representanteService.GetbyCedula(vm.Cedula);
            if (representante == true)
            {
                ModelState.AddModelError("Cedula", "La cedula ya está registrado.");
                return View("Create", vm);
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
