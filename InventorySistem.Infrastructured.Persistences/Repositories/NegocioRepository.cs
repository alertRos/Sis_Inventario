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
    public class NegocioRepository: GenericRepository<Negocios>, INegocioRepository
    {
        private readonly InventarioContext _context;
        public NegocioRepository(InventarioContext context):base(context)
        {
            _context = context;
        }

        public async Task<bool> GetByNombre (string nombre)
        {
            var negocio = await _context.Set<Negocios>().FirstOrDefaultAsync(n => n.Nombre == nombre);
            return negocio != null;
        }
    }
}
