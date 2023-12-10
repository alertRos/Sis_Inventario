using InventorySystem.Core.Application.Interface.Repositories;
using InventorySystem.Core.Domain.Entities;
using InventorySystem.Infrastructured.Persistences.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InventorySystem.Infrastructured.Persistences.Repositories
{
    public class MarcaRepository: GenericRepository<Marcas>, IMarcaRepository
    {
        private readonly InventarioContext _context;
        public MarcaRepository(InventarioContext context):base(context)
        {
            _context = context;
        }
    }
}
