using InventorySystem.Core.Application.Interface.Repositories;
using InventorySystem.Core.Application.Interface.Services;
using InventorySystem.Core.Application.ViewModel.Usuario;
using InventorySystem.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> GetEmail(UsuarioSaveViewModel vm)
        {
            var user = await _repository.GetEmail(vm);
            return user;
        }
        public async Task<UsuarioViewModel> Login(LoginViewModel vm)
        {
            Usuario users = await _repository.LoginAsync(vm);

            if (users == null)
                return null;

            UsuarioViewModel uservm = new();
            uservm.Id = users.Id;
            uservm.Nombre = users.Nombre;
            uservm.Email = users.Email;
            uservm.Password = users.Password;
            uservm.RoleName = users.RoleName;

            return uservm;
        }

        public async Task<UsuarioSaveViewModel> Add(UsuarioSaveViewModel vm)
        {
            Usuario usuario = new();
            usuario.Id = vm.Id;
            usuario.Nombre = vm.Nombre;
            usuario.Email = vm.Email;
            usuario.Password = vm.Password;
            usuario.RoleName = vm.RoleName;
            usuario = await _repository.AddAsync(usuario);

            UsuarioSaveViewModel usuarioSave = new();
            usuarioSave.Id = usuario.Id;
            usuarioSave.Nombre = usuario.Nombre;
            usuarioSave.Email = usuario.Email;
            usuarioSave.Password = usuario.Password;
            usuarioSave.RoleName = usuario.RoleName;
            usuarioSave.IdNegocio = vm.IdNegocio;
            return usuarioSave;
            
        }
        public async Task<UsuarioSaveViewModel> Delete(int id)
        {
            var usuario = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(usuario);
            UsuarioSaveViewModel usuarioSave = new();
            usuarioSave.Id = usuario.Id;
            usuarioSave.Nombre = usuario.Nombre;
            usuarioSave.Email = usuario.Email;
            usuarioSave.Password = usuario.Password;
            usuarioSave.RoleName = usuario.RoleName;
            return usuarioSave;

        }

        public async Task<List<UsuarioViewModel>> GetAllViewModel()
        {
            var userList = await _repository.GetAllWithIncludesAsync(new List<string> { "Representantes" });
            return userList.Select(a => new UsuarioViewModel
            {
                Id = a.Id,
                Nombre = a.Nombre,
                Email = a.Email,
                RoleName = a.RoleName

            }).ToList();
        }

        public Task<UsuarioSaveViewModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UsuarioSaveViewModel> Update(UsuarioSaveViewModel vm)
        {
            Usuario usuario = new();
            usuario.Id = vm.Id;
            usuario.Nombre = vm.Nombre;
            usuario.Email = vm.Email;
            usuario.Password = vm.Password;
            usuario.RoleName = vm.RoleName;
            usuario = await _repository.UpdateAsync(usuario);

            UsuarioSaveViewModel usuarioSave = new();
            usuarioSave.Id = usuario.Id;
            usuarioSave.Nombre = usuario.Nombre;
            usuarioSave.Email = usuario.Email;
            usuarioSave.Password = usuario.Password;
            usuarioSave.RoleName = usuario.RoleName;
            return usuarioSave;

        }
    }
}
