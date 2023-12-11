using InventorySystem.Core.Application.Interface.Repositories;
using InventorySystem.Core.Domain.Entities;
using InventorySystem.Infrastructured.Persistences.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Infrastructured.Persistences.Repositories
{
    public class ProductoRepository: GenericRepository<Producto>, IProductoRepository
    {
        private readonly InventarioContext _context;
        public ProductoRepository(InventarioContext context):base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> GetBy (string? nombre, int? idMarca, int? idCategoria, int? idProveedor, bool? fechaCaducidad)
        {
            try
            {
                var listProductos = await this.GetAllWithIncludesAsync(new List<string> { "IdCategoriaNavigation", "IdMarcaNavigation", "IdProveedorNavigation", "Negocios" });
                if(fechaCaducidad != false)
                {
                    listProductos = listProductos.OrderBy(p => p.FechaCaducidad?.Year) .ToList();
                }
                if (nombre != null)
                {
                    listProductos = listProductos.Where(p => p.Nombre.ToLower().Contains(nombre.ToLower())).ToList();
                }
                if (idCategoria != null)
                {
                    listProductos = listProductos.Where(p => p.IdCategoria == idCategoria).ToList();
                }
                if (idMarca != null)
                {
                    listProductos = listProductos.Where(p => p.IdMarca == idMarca).ToList();
                }
                if(idProveedor != null)
                {
                    listProductos = listProductos.Where(p => p.IdProveedor == idProveedor).ToList();
                }
                return listProductos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
