using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Cmp;
using SisInventario.Dto.Email;
using SisInventario.Helper;
using SisInventario.Interface;
using SisInventario.Middlewares;
using SisInventario.Models;

namespace SisInventario.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly InventarioContext _context;
        private readonly IEmailService _emailService;
        private readonly ValidateSession _validateSession;

        public UsuariosController(InventarioContext context, IEmailService emailService, ValidateSession validateSession)
        {
            _context = context;
            _emailService = emailService;
            _validateSession = validateSession;
        }

        public IActionResult Login()
        {
            if (_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Usuario usuario)
        {
            if (_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (usuario == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            string constraseña = PasswordEncryption.EncryptionPass(usuario.Password);
            Usuario user = await _context.Set<Usuario>().FirstOrDefaultAsync(u => u.Email == usuario.Email && u.Password == constraseña);
            if (user != null)
            {
                HttpContext.Session.Set<Usuario>("user", usuario);
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
                ModelState.AddModelError("Email", "Revise sus credenciales");
                return View("Login", usuario);
        }

        public IActionResult Logout()
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            HttpContext.Session.Remove("user");
            return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return _context.Usuarios != null ? 
                          View(await _context.Usuarios.ToListAsync()) :
                          Problem("Entity set 'InventarioContext.Usuarios'  is null.");
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }


        public IActionResult Create()
        {
            if (_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Password,Email, IdRole, IdNegocio")] Usuario usuario)
        {
            if (_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!ModelState.IsValid) {
                return View("Create", usuario);
            }

                usuario.IdRole = 1;
                usuario.IdNegocio = 1;
                usuario.Password = PasswordEncryption.EncryptionPass(usuario.Password);
            usuario.ConfirmPassword = "";
            var user = await _context.Usuarios.Where(u=>u.Email == usuario.Email).FirstOrDefaultAsync();
            if (user != null)
            {
                ModelState.AddModelError("Email", "El correo electrónico ya está registrado.");
                return View("Create", usuario);
            }

            await _context.AddAsync(usuario);
                await _context.SaveChangesAsync();
                EmailRequest emailRequest = new()
                {
                    To = usuario.Email,
                    Subject = "Bienvenido " + usuario.Nombre + " a Sistema de Inventario",
                    Body = "Bienvenido " + usuario.Nombre + " a Sistema de Inventario de su empresa"
                };
                await _emailService.SendEmailAsync(emailRequest);
                return RedirectToAction(nameof(Login));

        }


        public IActionResult ChangePassword ()
        {
            if (_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(Usuario usuario)
        {
            if (_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (usuario == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var user = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Email == usuario.Email);
            if (user == null)
            {
                ModelState.AddModelError("Email", "El correo electrónico no se encontro.");
                return View("ChangePassword", usuario);
            }
            string enlace = "https://localhost:7268/Usuarios/Edit/" + user.Id;
            EmailRequest emailRequest = new()
            {
                To = user.Email,
                Subject = "Recuperación de contraseña",
                Body = "Hacer clic aqui, para cambiar contraseña:  " + ' ' + $"<a href=\"{enlace}\">Enlace</a>"
            };
            await _emailService.SendEmailAsync(emailRequest);
            return RedirectToAction(nameof(Login));
        }
        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Email, IdRole, IdNegocio")] Usuario usuario)
        {
            if (_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    usuario.Password = PasswordEncryption.EncryptionPass(usuario.Password);
                    _context.Entry(usuario).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'InventarioContext.Usuarios'  is null.");
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
          return (_context.Usuarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
