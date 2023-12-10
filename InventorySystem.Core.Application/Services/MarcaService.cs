using InventorySystem.Core.Application.Interface.Repositories;
using InventorySystem.Core.Application.Interface.Services;
using InventorySystem.Core.Application.ViewModel.Categoria;
using InventorySystem.Core.Application.ViewModel.Marca;
using InventorySystem.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Application.Services
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _repository;
        public MarcaService(IMarcaRepository repository)
        {
            _repository = repository;
        }

        public async Task<MarcaSaveViewModel> Add(MarcaSaveViewModel vm)
        {
            Marcas marca = new();
            marca.Id = vm.Id;
            marca.Nombre = vm.Nombre;
            marca = await _repository.AddAsync(marca);

            MarcaSaveViewModel vmMarca = new();
            vmMarca.Id = marca.Id;
            vmMarca.Nombre = marca.Nombre;
            return vmMarca;
        }

        public async Task<MarcaSaveViewModel> Delete(int id)
        {
            var categoria = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(categoria);
            MarcaSaveViewModel Marcasave = new();
            Marcasave.Id = categoria.Id;
            Marcasave.Nombre = categoria.Nombre;
            return Marcasave;

        }

        public async Task<List<MarcaViewModel>> GetAllViewModel()
        {
            var marcas = await _repository.GetAllAsync();
            var marcasVm = marcas.Select(c => new MarcaViewModel
            {
                Id = c.Id,
                Nombre = c.Nombre,
                CountProductos = c.Productos.Count()
            }).ToList();
            return marcasVm;
        }

        public async Task<MarcaSaveViewModel> GetById(int id)
        {
            var marcas = await _repository.GetByIdAsync(id);
            MarcaSaveViewModel marcasave = new();
            marcasave.Id = marcas.Id;
            marcasave.Nombre = marcas.Nombre;
            return marcasave;
        }

        public async Task<MarcaSaveViewModel> Update(MarcaSaveViewModel vm)
        {
            Marcas marca = new();
            marca.Id = vm.Id;
            marca.Nombre = vm.Nombre;
            marca = await _repository.UpdateAsync(marca);

            MarcaSaveViewModel marcaSave = new();
            marcaSave.Id = marca.Id;
            marcaSave.Nombre = marca.Nombre;
            return marcaSave;
        }
        public async Task<List<MarcaViewModel>> GetPagination(int paginaActual, int tamanoPagina)
        {
            Expression<Func<Marcas, object>> orderBy = e => e.Id;
            var marcas = await _repository.ObtenerPaginadosAsync(paginaActual, tamanoPagina, orderBy);
            var total = await _repository.GetTotalItemsCountAsync();
            var marcasVm = marcas.Select((c,index) => new MarcaViewModel
            {
                Id = c.Id,
                Nombre = c.Nombre,
                CountProductos = c.Productos.Count(),
                TotalItems = total,
            }).ToList();
            return marcasVm;

        }
    }
}
