using InventorySystem.Core.Application.Interface.Repositories;
using InventorySystem.Core.Application.Interface.Services;
using InventorySystem.Core.Application.ViewModel.Producto;
using InventorySystem.Core.Application.ViewModel.Proveedor;
using InventorySystem.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Application.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;
        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }
        public async Task<ProductoSaveViewModel> Add(ProductoSaveViewModel vm)
        {
            Producto producto = new();
            producto.Id = vm.Id;
            producto.Nombre = vm.Nombre;
            producto.Precio = vm.Precio;
            producto.Descripcion = vm.Descripcion;
            producto.IdCategoria = vm.IdCategoria;
            producto.IdMarca = vm.IdMarca;
            producto.IdProveedor = vm.IdProveedor;
            producto.FechaCaducidad = vm.FechaCaducidad;
            producto.AreaUbicacion = vm.AreaUbicacion;
            producto.Stock = vm.Stock;
            producto.ImgUrl = vm.ImgUrl;
            producto = await _repository.AddAsync(producto);

            ProductoSaveViewModel vmProducto = new();
            vmProducto.Id = producto.Id;
            vmProducto.Nombre = producto.Nombre;
            vmProducto.Precio = producto.Precio;
            vmProducto.Descripcion = producto.Descripcion;
            vmProducto.IdCategoria = producto.IdCategoria;
            vmProducto.IdMarca = producto.IdMarca;
            vmProducto.IdProveedor = producto.IdProveedor;
            vmProducto.FechaCaducidad = producto.FechaCaducidad;
            vmProducto.AreaUbicacion = producto.AreaUbicacion;
            vmProducto.ImgUrl = producto.ImgUrl;
            vmProducto.Stock = producto.Stock;
            return vmProducto;
        }

        public async Task<ProductoSaveViewModel> Delete(int id)
        {
            var producto = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(producto);
            ProductoSaveViewModel productoSave = new();
            productoSave.Id = producto.Id;
            productoSave.Nombre = producto.Nombre;
            productoSave.Precio = producto.Precio;
            productoSave.Descripcion = producto.Descripcion;
            productoSave.IdCategoria = producto.IdCategoria;
            productoSave.IdMarca = producto.IdMarca;
            productoSave.IdProveedor = producto.IdProveedor;
            productoSave.FechaCaducidad = producto.FechaCaducidad;
            productoSave.AreaUbicacion = producto.AreaUbicacion;
            productoSave.Stock = producto.Stock;
            productoSave.ImgUrl = producto.ImgUrl;
            return productoSave;
        }

        public async Task<List<ProductoViewModel>> GetAllViewModel()
        {
            var productos = await _repository.GetAllWithIncludesAsync(new List<string> { "IdCategoriaNavigation", "IdMarcaNavigation", "IdProveedorNavigation", "Negocios" });
            var productosVm = productos.Select(p => new ProductoViewModel
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                Descripcion = p.Descripcion,
                Categoria = p.IdCategoriaNavigation.Nombre,
                Marca = p.IdMarcaNavigation.Nombre,
                FechaCaducidad = p.FechaCaducidad,
                AreaUbicacion = p.AreaUbicacion,
                Stock = p.Stock,
                Proveedor = p.IdProveedorNavigation.Nombre,
                Negocio = p.Negocios.Nombre,
                IdMarca = p.IdMarca,
                IdCategoria = p.IdCategoria,
                IdProveedor = p.IdProveedor,
                IdNegocio = p.IdNegocio,
                ImgUrl = p.ImgUrl
                
            }).ToList();
            return productosVm;
        }

        public async Task<IEnumerable<ProductoViewModel>> GetBy(string? nombre,int? idMarca, int? idCategoria, int? idProveedor)
        {
            var productosGet = await _repository.GetBy(nombre,idMarca, idCategoria, idProveedor);
            var productos = productosGet.Select(p => new ProductoViewModel
            {
                Nombre = p.Nombre,
                Precio = p.Precio,
                Descripcion = p.Descripcion,
                Categoria = p.IdCategoriaNavigation.Nombre,
                Marca = p.IdMarcaNavigation.Nombre,
                FechaCaducidad = p.FechaCaducidad,
                AreaUbicacion = p.AreaUbicacion,
                Stock = p.Stock,
                Proveedor = p.IdProveedorNavigation.Nombre,
                IdMarca = p.IdMarca,
                IdCategoria = p.IdCategoria,
                IdProveedor = p.IdProveedor,
                IdNegocio = p.IdNegocio,
                ImgUrl = p.ImgUrl,
                Id = p.Id
            }).ToList();

            return productos;

        }

        public async Task<ProductoSaveViewModel> GetById(int id)
        {
            var producto = await _repository.GetByIdAsync(id);
            ProductoSaveViewModel productoSave = new();
            productoSave.Id = producto.Id;
            productoSave.Nombre = producto.Nombre;
            productoSave.Precio = producto.Precio;
            productoSave.Descripcion = producto.Descripcion;
            productoSave.IdCategoria = producto.IdCategoria;
            productoSave.IdMarca = producto.IdMarca;
            productoSave.IdProveedor = producto.IdProveedor;
            productoSave.FechaCaducidad = producto.FechaCaducidad;
            productoSave.AreaUbicacion = producto.AreaUbicacion;
            productoSave.Stock = producto.Stock;
            productoSave.ImgUrl = producto.ImgUrl;
            return productoSave;
        }

        public async Task<ProductoSaveViewModel> Update(ProductoSaveViewModel vm)
        {
            Producto producto = new();
            producto.Id = vm.Id;
            producto.Nombre = vm.Nombre;
            producto.Precio = vm.Precio;
            producto.Descripcion = vm.Descripcion;
            producto.IdCategoria = vm.IdCategoria;
            producto.IdMarca = vm.IdMarca;
            producto.IdProveedor = vm.IdProveedor;
            producto.FechaCaducidad = vm.FechaCaducidad;
            producto.AreaUbicacion = vm.AreaUbicacion;
            producto.Stock = vm.Stock;
            producto.ImgUrl = vm.ImgUrl;
            producto = await _repository.UpdateAsync(producto);

            ProductoSaveViewModel model = new();
            model.Id = producto.Id;
            model.Nombre = producto.Nombre;
            model.Precio = producto.Precio;
            model.Descripcion = producto.Descripcion;
            model.IdCategoria = producto.IdCategoria;
            model.IdMarca = producto.IdMarca;
            model.IdProveedor = producto.IdProveedor;
            model.FechaCaducidad = producto.FechaCaducidad;
            model.AreaUbicacion = producto.AreaUbicacion;
            model.Stock = producto.Stock;
            model.ImgUrl = producto.ImgUrl;
            return model;



        }
    }
}
