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
    public class ProductosController : Controller
    {
        private readonly InventarioContext _context;

        public ProductosController(InventarioContext context)
        {
            _context = context;
        }

        // GET: Productoes
        public async Task<IActionResult> Index()
        {
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "Id", "Categoria");
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "Id", "Marca");
            var inventarioContext = _context.Productos.Include(p => p.IdCategoriaNavigation).Include(p => p.IdMarcaNavigation).Include(p => p.IdProveedorNavigation);

            var listProductos = await inventarioContext.Select(p=>new Producto
            {
                Nombre = p.Nombre,
                Precio = p.Precio,
                Descripcion = p.Descripcion,
                NombreCategoria = p.IdCategoriaNavigation.Categoria,
                NombreMarca = p.IdMarcaNavigation.Marca,
                FechaCaducidad = p.FechaCaducidad,
                AreaUbicacion = p.AreaUbicacion,
                Stock = p.Stock,
                IdMarca = p.IdMarca,
                IdCategoria = p.IdCategoria,
                IdProveedor = p.IdProveedor,
                Id = p.Id,
                NombreProveedor = p.IdProveedorNavigation.Proveedor,

            }).ToListAsync();
            return View(listProductos);
        }


        public async Task<IActionResult> GetBy (string? nombre, int ? idCategoria, int? idMarca)
        {
            try
            {
                if (nombre == null && idCategoria == null && idMarca == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                var inventarioContext = _context.Productos.Include(p => p.IdCategoriaNavigation).Include(p => p.IdMarcaNavigation).Include(p => p.IdProveedorNavigation);
                var listProductos = await inventarioContext.Select(p => new Producto
                {
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                    Descripcion = p.Descripcion,
                    NombreCategoria = p.IdCategoriaNavigation.Categoria,
                    NombreMarca = p.IdMarcaNavigation.Marca,
                    FechaCaducidad = p.FechaCaducidad,
                    AreaUbicacion = p.AreaUbicacion,
                    Stock = p.Stock,
                    NombreProveedor = p.IdProveedorNavigation.Proveedor,
                    IdMarca = p.IdMarca,
                    IdCategoria = p.IdCategoria,
                    IdProveedor = p.IdProveedor,
                    Id = p.Id

                }).ToListAsync();
                if (nombre != null)
                {
                    listProductos = listProductos.Where(p => p.Nombre == nombre).ToList();
                }
                if (idCategoria != null)
                {
                    listProductos = listProductos.Where(p => p.IdCategoria == idCategoria).ToList();
                }
                if (idMarca != null)
                {
                    listProductos = listProductos.Where(p => p.IdMarca == idMarca).ToList();
                }
                ViewData["IdCategoria"] = new SelectList(_context.Categoria, "Id", "Categoria");
                ViewData["IdMarca"] = new SelectList(_context.Marcas, "Id", "Marca");

                return View("Index", listProductos);


            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return RedirectToAction(nameof(Index));

        }

        
        // GET: Productoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.IdCategoriaNavigation)
                .Include(p => p.IdMarcaNavigation)
                .Include(p => p.IdProveedorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productoes/Create
        public IActionResult Create()
        {
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "Id", "Id");
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "Id", "Id");
            ViewData["IdProveedor"] = new SelectList(_context.Proveedors, "Id", "Id");
            return View();
        }

        // POST: Productoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Precio,Descripcion,IdCategoria,IdMarca,FechaCaducidad,AreaUbicacion,Stock,IdProveedor")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "Id", "Id", producto.IdCategoria);
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "Id", "Id", producto.IdMarca);
            ViewData["IdProveedor"] = new SelectList(_context.Proveedors, "Id", "Id", producto.IdProveedor);
            return View(producto);
        }

        // GET: Productoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "Id", "Id", producto.IdCategoria);
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "Id", "Id", producto.IdMarca);
            ViewData["IdProveedor"] = new SelectList(_context.Proveedors, "Id", "Id", producto.IdProveedor);
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Precio,Descripcion,IdCategoria,IdMarca,FechaCaducidad,AreaUbicacion,Stock,IdProveedor")] Producto producto)
        {
            if (id != producto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.Id))
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
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "Id", "Id", producto.IdCategoria);
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "Id", "Id", producto.IdMarca);
            ViewData["IdProveedor"] = new SelectList(_context.Proveedors, "Id", "Id", producto.IdProveedor);
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.IdCategoriaNavigation)
                .Include(p => p.IdMarcaNavigation)
                .Include(p => p.IdProveedorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Productos == null)
            {
                return Problem("Entity set 'InventarioContext.Productos'  is null.");
            }
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
          return (_context.Productos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
