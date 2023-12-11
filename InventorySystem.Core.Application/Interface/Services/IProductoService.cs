using InventorySystem.Core.Application.Interface.Services;
using InventorySystem.Core.Application.ViewModel.Producto;
using InventorySystem.Core.Application.ViewModel.Proveedor;
using InventorySystem.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Application.Interface.Services
{
    public interface IProductoService:IGenericService<ProductoSaveViewModel, ProductoViewModel>
    {
        Task<IEnumerable<ProductoViewModel>> GetBy(string? nombre, int? idMarca, int? idCategoria, int? idProveedor, bool? fechaCaducidad);
    }
}
