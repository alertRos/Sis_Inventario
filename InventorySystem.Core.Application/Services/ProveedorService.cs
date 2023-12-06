using InventorySystem.Core.Application.Interface.Repositories;
using InventorySystem.Core.Application.Interface.Services;
using InventorySystem.Core.Application.ViewModel.Proveedor;
using InventorySystem.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Application.Services
{
    public class ProveedorService : IProveedorService
    {
        private readonly IProveedorRepository _repository;
        public ProveedorService(IProveedorRepository repository) 
        {
            _repository = repository;
        }
        public async Task<ProveedorSaveViewModel> Add(ProveedorSaveViewModel vm)
        {
            Proveedores proveedore = new();
            proveedore.Id = vm.Id;
            proveedore.Nombre = vm.Nombre;
            proveedore = await _repository.AddAsync(proveedore);

            ProveedorSaveViewModel vmProveedor = new();
            vmProveedor.Id = proveedore.Id;
            vmProveedor.Nombre = proveedore.Nombre;
            return vmProveedor;

        }

        public async Task<ProveedorSaveViewModel> Delete(int id)
        {
            var proveedor = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(proveedor);
            ProveedorSaveViewModel vmProveedor = new();
            vmProveedor.Id = proveedor.Id;
            vmProveedor.Nombre = proveedor.Nombre;
            return vmProveedor;
        }

        public async Task<List<ProveedorViewModel>> GetAllViewModel()
        {
            var proveedores =await  _repository.GetAllWithIncludesAsync(new List<string> { "Productos" });
            var proveedoresVm =  proveedores.Select(c => new ProveedorViewModel
            {
                Id = c.Id,
                Nombre = c.Nombre,
                CountProductos = c.Productos.Count()
            }).ToList();
            return proveedoresVm;
        }

        public async Task<ProveedorSaveViewModel> GetById(int id)
        {
            var proveedor = await _repository.GetByIdAsync(id);
            ProveedorSaveViewModel vmProveedor = new();
            vmProveedor.Id = proveedor.Id;
            vmProveedor.Nombre = proveedor.Nombre;
            return vmProveedor;
        }

        public async Task<ProveedorSaveViewModel> Update(ProveedorSaveViewModel vm)
        {
            Proveedores proveedore = new();
            proveedore.Id = vm.Id;
            proveedore.Nombre = vm.Nombre;
            proveedore = await _repository.UpdateAsync(proveedore);

            ProveedorSaveViewModel vmProveedor = new();
            vmProveedor.Id = proveedore.Id;
            vmProveedor.Nombre = proveedore.Nombre;
            return vmProveedor;
        }
    }
}
