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
    public class RepresentanteRepository: GenericRepository<Representante>, IRepresentanteRepository
    {
        private readonly InventarioContext _context;
        public RepresentanteRepository(InventarioContext context):base(context)
        {
            _context = context;
        }
        public async Task<bool> GetByCedula(string cedula)
        {
            var representante = await _context.Set<Representante>().FirstOrDefaultAsync(r => r.Cedula == cedula);
            return representante != null;
        }
    }
}
