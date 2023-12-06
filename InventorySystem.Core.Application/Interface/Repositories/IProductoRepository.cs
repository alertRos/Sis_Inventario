using InventorySystem.Core.Application.Interface.Repositories;
using InventorySystem.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Application.Interface.Repositories
{
    public interface IProductoRepository:IGenericRepository<Producto>
    {
        Task<IEnumerable<Producto>> GetBy(string? nombre, int? idMarca, int? idCategoria, int? idProveedor);
    }
}
