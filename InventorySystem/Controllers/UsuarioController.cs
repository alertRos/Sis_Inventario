﻿using InventorySystem.Core.Application.Interface.Services;
using InventorySystem.Core.Application.ViewModel.Usuario;
using InventorySystem.Middlewares;
using InventorySystem.Core.Application.Helper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using InventorySystem.Core.Application.Services;

namespace InventorySystem.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ValidateUserSession _validateUserSession;
        public UsuarioController(IUsuarioService usuarioService, ValidateUserSession validateUser)
        {
            _validateUserSession = validateUser;
            _usuarioService = usuarioService;
        }
        public async Task<IActionResult> Login()
        {
            if (_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            UsuarioViewModel uservm = await _usuarioService.Login(vm);
            if (uservm != null)
            {
                HttpContext.Session.Set<UsuarioViewModel>("user", uservm);
                if(uservm.RoleName == "Read")
                {
                    return RedirectToRoute(new { controller = "Home", action = "Dashboard" });

                }
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            else
            {
                ModelState.AddModelError("Email", "Usuario o contraseña incorrecta");
            }
            return View(vm);
        }
        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.hasUser() && !_validateUserSession.hasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View(await _usuarioService.GetAllViewModel());
        }

        //Es para que funcione en el Admin, cuando entre
        public IActionResult Register()
        {
            if (!_validateUserSession.hasUser() && !_validateUserSession.hasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UsuarioSaveViewModel vm)
        {
            //Cambiar el controller para ponerlo al inicio en si de nuestra pagina donde se crea el negocio
            if (!_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            //Cambiar el controller para ponerlo al inicio en si de nuestra pagina donde se crea el negocio
            if (!_validateUserSession.hasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            } 
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            await _usuarioService.Add(vm);
            return RedirectToRoute(new { controller = "Representante", action = "Register" });
        }

        [ServiceFilter(typeof(ValidarNegocioCreateFilterAttribute))]
        public async Task<IActionResult> Create()
        {
            if (_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

                UsuarioSaveViewModel vm = new();
                vm.RoleName = "Administrador";

                return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UsuarioSaveViewModel vm)
        {
            if (_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var user = await _usuarioService.GetEmail(vm);
            if (user == true)
            {
                ModelState.AddModelError("Email", "El correo electrónico ya está registrado.");
                return View("Create", vm);
            }
            TempData["Usuario"] = JsonConvert.SerializeObject(vm);

            return RedirectToRoute(new { controller = "Representante", action = "Create" });
        }

        public async Task<IActionResult> Password(int id)
        {
            if (_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            var vm = await _usuarioService.GetById(id);
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Password(UsuarioSaveViewModel vm)
        {
            if (_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            vm.Password = PasswordEncryption.Encrypt(vm.Password);
            await _usuarioService.Update(vm);
            return RedirectToRoute(new { controller = "Usuario", action = "Login" });
        }

        public async Task<IActionResult> ChangePassword()
        {
            if (_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(UsuarioSaveViewModel vm)
        {
            if (_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            var user = await _usuarioService.ChangePassword(vm);
            if (user == null)
            {
                return View(vm);
            }

            return RedirectToAction(nameof(Login));
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Login" });
            }
            if (!_validateUserSession.hasAdmin())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Login" });
            }
            await _usuarioService.Delete(id);
            return RedirectToRoute(new { controller = "Usuario", action = "Index" });
        }

        public async Task<IActionResult> Edit (int id)
        {
            if (_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Login" });
            }
            if (_validateUserSession.hasAdmin())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Login" });
            }
            var vm = await _usuarioService.GetById(id);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UsuarioSaveViewModel vm)
        {
            if (_validateUserSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Login" });
            }
            if (_validateUserSession.hasAdmin())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Login" });
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("ConfirmPassword", "Las contraseñas no son iguales");

                return View(vm);
            }
            vm.Password = PasswordEncryption.Encrypt(vm.Password);
            await _usuarioService.Update(vm);
            return RedirectToRoute(new { controller = "Usuario", action = "Login" });
        }
    }
}

