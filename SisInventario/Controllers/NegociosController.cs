using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SisInventario.Models;

namespace SisInventario.Controllers
{
    public class NegociosController : Controller
    {
        private readonly InventarioContext _context;

        public NegociosController(InventarioContext context)
        {
            _context = context;
        }

        // GET: Negocios
        public async Task<IActionResult> Index()
        {
            var inventarioContext = _context.Negocios.Include(n => n.IdRepresentanteNavigation);
            return View(await inventarioContext.ToListAsync());
        }

        // GET: Negocios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Negocios == null)
            {
                return NotFound();
            }

            var negocios = await _context.Negocios
                .Include(n => n.IdRepresentanteNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (negocios == null)
            {
                return NotFound();
            }

            return View(negocios);
        }

        // GET: Negocios/Create
        public IActionResult Create()
        {
            ViewData["IdRepresentante"] = new SelectList(_context.Clientes, "Id", "Id");
            return View();
        }

        // POST: Negocios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Negocio,Telefono,Direccion,Email,IdRepresentante")] Negocios negocios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(negocios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRepresentante"] = new SelectList(_context.Clientes, "Id", "Id", negocios.IdRepresentante);
            return View(negocios);
        }

        // GET: Negocios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Negocios == null)
            {
                return NotFound();
            }

            var negocios = await _context.Negocios.FindAsync(id);
            if (negocios == null)
            {
                return NotFound();
            }
            ViewData["IdRepresentante"] = new SelectList(_context.Clientes, "Id", "Id", negocios.IdRepresentante);
            return View(negocios);
        }

        // POST: Negocios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Negocio,Telefono,Direccion,Email,IdRepresentante")] Negocios negocios)
        {
            if (id != negocios.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(negocios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NegociosExists(negocios.Id))
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
            ViewData["IdRepresentante"] = new SelectList(_context.Clientes, "Id", "Id", negocios.IdRepresentante);
            return View(negocios);
        }

        // GET: Negocios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Negocios == null)
            {
                return NotFound();
            }

            var negocios = await _context.Negocios
                .Include(n => n.IdRepresentanteNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (negocios == null)
            {
                return NotFound();
            }

            return View(negocios);
        }

        // POST: Negocios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Negocios == null)
            {
                return Problem("Entity set 'InventarioContext.Negocios'  is null.");
            }
            var negocios = await _context.Negocios.FindAsync(id);
            if (negocios != null)
            {
                _context.Negocios.Remove(negocios);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NegociosExists(int id)
        {
          return (_context.Negocios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
