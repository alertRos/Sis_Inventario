﻿using InventorySystem.Core.Application.Interface.Repositories;
using InventorySystem.Core.Domain.Entities;
using InventorySystem.Infrastructured.Persistences.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Infrastructured.Persistences.Repositories
{
    public class CategoriaRepository: GenericRepository<Categorias>, ICategoriaRepository
    {
        private readonly InventarioContext _context;
        public CategoriaRepository(InventarioContext context):base(context)
        {
            _context = context;
        }
    }
}
