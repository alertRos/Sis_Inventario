using InventorySystem.Core.Application.Interface.Repositories;
using InventorySystem.Core.Application.Interface.Services;
using InventorySystem.Core.Application.ViewModel.Categoria;
using InventorySystem.Core.Application.ViewModel.Representante;
using InventorySystem.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Application.Services
{
    public class RepresentanteService : IRepresentanteService
    {
        private readonly IRepresentanteRepository _representanteRepository;
        public RepresentanteService(IRepresentanteRepository representanteRepository)
        {
            _representanteRepository = representanteRepository;
        }

        public async Task<RepresentanteSaveViewModel> Add(RepresentanteSaveViewModel vm)
        {
            Representante representante = new();
            representante.Id = vm.Id;
            representante.Nombre = vm.Nombre;
            representante.Apellido = vm.Apellido;
            representante.Telefono = vm.Telefono;
            representante.Cedula = vm.Cedula;
            representante.IdUsuario = vm.IdUsuario;
            representante.IdNegocio = vm.IdNegocio;

            representante = await _representanteRepository.AddAsync(representante);

            RepresentanteSaveViewModel vmRepresentante = new();
            vmRepresentante.Id = representante.Id;
            vmRepresentante.Nombre = representante.Nombre;
            vmRepresentante.Apellido = representante.Apellido;
            vmRepresentante.Telefono = representante.Telefono;
            vmRepresentante.Cedula = representante.Cedula;
            vmRepresentante.IdUsuario = representante.IdUsuario;
            vmRepresentante.IdNegocio = representante.IdNegocio;
            return vmRepresentante;

        }

        public async Task<RepresentanteSaveViewModel> Delete(int id)
        {
            var representante = await _representanteRepository.GetByIdAsync(id);
            await _representanteRepository.DeleteAsync(representante);
            RepresentanteSaveViewModel representanteSave = new();
            representanteSave.Id = representante.Id;
            representanteSave.Nombre = representante.Nombre;
            representanteSave.Apellido = representante.Apellido;
            representanteSave.Telefono = representante.Telefono;
            representanteSave.Cedula = representante.Cedula;
            representanteSave.IdUsuario = representante.IdUsuario;
            representanteSave.IdNegocio = representante.IdNegocio;
            return representanteSave;
        }

        public async Task<List<RepresentanteViewModel>> GetAllViewModel()
        {
            var representantes = await _representanteRepository.GetAllWithIncludesAsync(new List<string> { "Negocio", "Usuario" });
            var representantesVm = representantes.Select(c => new RepresentanteViewModel
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Apellido = c.Apellido,
                Telefono = c.Telefono,
                Cedula = c.Cedula,
                IdUsuario = c.IdUsuario,
                IdNegocio = c.IdNegocio,
                NombreUsuario = c.Usuario.Nombre,
                NombreNegocio = c.Negocio.Nombre
            }).ToList();
            return representantesVm;
        }

        public async Task<RepresentanteSaveViewModel> GetById(int id)
        {
            var representante = await _representanteRepository.GetByIdAsync(id);
            RepresentanteSaveViewModel representanteSave = new();
            representanteSave.Id = representante.Id;
            representanteSave.Nombre = representante.Nombre;
            representanteSave.Apellido = representante.Apellido;
            representanteSave.Telefono = representante.Telefono;
            representanteSave.Cedula = representante.Cedula;
            representanteSave.IdUsuario = representante.IdUsuario;
            representanteSave.IdNegocio = representante.IdNegocio;
            return representanteSave;
        }

        public async Task<RepresentanteSaveViewModel> Update(RepresentanteSaveViewModel vm)
        {
            Representante representante = new();
            representante.Id = vm.Id;
            representante.Nombre = vm.Nombre;
            representante.Apellido = vm.Apellido;
            representante.Telefono = vm.Telefono;
            representante.Cedula = vm.Cedula;
            representante.IdUsuario = vm.IdUsuario;
            representante.IdNegocio = vm.IdNegocio;

            representante = await _representanteRepository.UpdateAsync(representante);

            RepresentanteSaveViewModel vmRepresentante = new();
            vmRepresentante.Id = representante.Id;
            vmRepresentante.Nombre = representante.Nombre;
            vmRepresentante.Apellido = representante.Apellido;
            vmRepresentante.Telefono = representante.Telefono;
            vmRepresentante.Cedula = representante.Cedula;
            vmRepresentante.IdUsuario = representante.IdUsuario;
            vmRepresentante.IdNegocio = representante.IdNegocio;
            return vmRepresentante;

        }
    }
}
