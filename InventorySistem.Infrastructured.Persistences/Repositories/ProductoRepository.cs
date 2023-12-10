﻿using InventorySystem.Core.Application.Interface.Repositories;
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

        public async Task<IEnumerable<Producto>> GetBy (string? nombre, int? idMarca, int? idCategoria, int? idProveedor)
        {
            try
            {
                var listProductos = await this.GetAllWithIncludesAsync(new List<string> { "IdCategoriaNavigation", "IdMarcaNavigation", "IdProveedorNavigation", "Negocios" });

                var filteredProductos = listProductos
                          .Where(p => (string.IsNullOrEmpty(nombre) || p.Nombre.Contains(nombre))
                                   && (idCategoria == null || p.IdCategoria == idCategoria)
                                   && (idMarca == null || p.IdMarca == idMarca)
                                   && (idProveedor == null || p.IdProveedor == idProveedor))
                          .ToList();

                return filteredProductos.Any() ? filteredProductos : null;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
