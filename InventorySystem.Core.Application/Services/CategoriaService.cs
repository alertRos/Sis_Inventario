using InventorySystem.Core.Application.Interface.Repositories;
using InventorySystem.Core.Application.Interface.Services;
using InventorySystem.Core.Application.ViewModel.Categoria;
using InventorySystem.Core.Application.ViewModel.Usuario;
using InventorySystem.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Application.Services
{
    public class CategoriaService : ICategoryService
    {
        private readonly ICategoriaRepository _repository;
        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<CategoriaSaveViewModel> Add(CategoriaSaveViewModel vm)
        {
            Categorias categoria = new();
            categoria.Id = vm.Id;
            categoria.Nombre = vm.Nombre;
            categoria = await _repository.AddAsync(categoria);

            CategoriaSaveViewModel categoriaSave = new();
            categoriaSave.Id = categoria.Id;
            categoriaSave.Nombre = categoria.Nombre;
            return categoriaSave;
        }

        public async Task<CategoriaSaveViewModel> Delete(int id)
        {
            var categoria = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(categoria);
            CategoriaSaveViewModel categoriaSave = new();
            categoriaSave.Id = categoria.Id;
            categoriaSave.Nombre = categoria.Nombre;
            return categoriaSave;

        }

        public async Task<List<CategoriaViewModel>> GetAllViewModel()
        {
            var categorias = await _repository.GetAllAsync();
            var categoriasVm = categorias.Select(c => new CategoriaViewModel
            {
                Id = c.Id,
                Nombre = c.Nombre,
                CountProductos= c.Productos.Count()
            }).ToList();
            return categoriasVm;
        }

        public async Task<CategoriaSaveViewModel> GetById(int id)
        {
            var categoria = await _repository.GetByIdAsync(id);
            CategoriaSaveViewModel categoriaSave = new();
            categoriaSave.Id = categoria.Id;
            categoriaSave.Nombre = categoria.Nombre;
            return categoriaSave;
        }

        public async Task<CategoriaSaveViewModel> Update(CategoriaSaveViewModel vm)
        {
            Categorias categoria = new();
            categoria.Id = vm.Id;
            categoria.Nombre = vm.Nombre;
            categoria = await _repository.UpdateAsync(categoria);

            CategoriaSaveViewModel categoriaSave = new();
            categoriaSave.Id = categoria.Id;
            categoriaSave.Nombre = categoria.Nombre;
            return categoriaSave;
        }
    }
}
