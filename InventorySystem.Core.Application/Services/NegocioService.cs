using InventorySystem.Core.Application.Interface.Repositories;
using InventorySystem.Core.Application.Interface.Services;
using InventorySystem.Core.Application.ViewModel.Negocio;
using InventorySystem.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Application.Services
{
    public class NegocioService : INegocioService
    {
        private readonly INegocioRepository _repository;
        public NegocioService(INegocioRepository repository)
        {
            _repository = repository;
        }
        public async Task<NegocioSaveViewModel> Add(NegocioSaveViewModel vm)
        {
            Negocios negocios = new();
            negocios.Nombre = vm.Nombre;
            negocios.Direccion = vm.Direccion;
            negocios.Telefono = vm.Telefono;
            negocios.Email = vm.Email;
            negocios =await _repository.AddAsync(negocios);

            NegocioSaveViewModel negocioSave = new();
            negocioSave.Id = negocios.Id;
            negocioSave.Nombre = negocios.Nombre;
            negocioSave.Direccion = negocios.Direccion;
            negocioSave.Telefono = negocios.Telefono;
            negocioSave.Email = negocios.Email;
            return negocioSave;

        }

        public async Task<NegocioSaveViewModel> Delete(int id)
        {
            var negocio = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(negocio);
            NegocioSaveViewModel negocioSave = new();
            negocioSave.Id = negocio.Id;
            negocioSave.Nombre = negocio.Nombre;
            negocioSave.Direccion = negocio.Direccion;
            negocioSave.Telefono = negocio.Telefono;
            negocioSave.Email = negocio.Email;
            return negocioSave;

        }

        public async Task<List<NegocioViewModel>> GetAllViewModel()
        {
            var negocios = await _repository.GetAllAsync();
            var negociosVm = negocios.Select(n => new NegocioViewModel
            {
                Id = n.Id,
                Nombre = n.Nombre,
                Direccion = n.Direccion,
                Telefono = n.Telefono,
                Email = n.Email,
                CountRepresentante = n.Representantes.Count()
            }).ToList();
            return negociosVm;
        }

        public async Task<NegocioSaveViewModel> GetById(int id)
        {
            var negocio = await _repository.GetByIdAsync(id);
            NegocioSaveViewModel negocioSave = new();
            negocioSave.Id = negocio.Id;
            negocioSave.Nombre = negocio.Nombre;
            negocioSave.Direccion = negocio.Direccion;
            negocioSave.Telefono = negocio.Telefono;
            negocioSave.Email = negocio.Email;
            return negocioSave;
        }

        public async Task<bool> GetByNombre(string nombre)
        {
            var negocio =await _repository.GetByNombre(nombre);
            if (negocio == false)
            {
                return false;
            }
            return true;

        }

        public async Task<NegocioSaveViewModel> Update(NegocioSaveViewModel vm)
        {
            Negocios negocio = new();
            negocio.Id = vm.Id;
            negocio.Nombre = vm.Nombre;
            negocio.Direccion = vm.Direccion;
            negocio.Telefono = vm.Telefono;
            negocio.Email = vm.Email;
            negocio = await _repository.UpdateAsync(negocio);

            NegocioSaveViewModel negocioSave = new();
            negocioSave.Id = negocio.Id;
            negocioSave.Nombre = negocio.Nombre;
            negocioSave.Direccion = negocio.Direccion;
            negocioSave.Telefono = negocio.Telefono;
            negocioSave.Email = negocio.Email;
            return negocioSave;
        }
    }
}
