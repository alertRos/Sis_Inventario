using InventorySystem.Core.Application.Helper;
using InventorySystem.Core.Application.Interface.Repositories;
using InventorySystem.Core.Application.ViewModel.Usuario;
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
    public class UsuarioRepository: GenericRepository<Usuario>, IUsuarioRepository
    {
        private readonly InventarioContext _context;
        public UsuarioRepository(InventarioContext context):base(context)
        {
            _context = context;
        }

        public override async Task<Usuario> AddAsync(Usuario entity)
        {
            //Estoy cumpliendo con el pincipio de liskov, ya que estoy sobreescribiendo el metodo AddAsync de la clase GenericRepository
            entity.Password = PasswordEncryption.Encrypt(entity.Password);
            return await base.AddAsync(entity);
        }

        public async Task<bool> GetEmail(UsuarioSaveViewModel vm)
        {
            var user = await _context.Set<Usuario>().FirstOrDefaultAsync(u => u.Email == vm.Email);
            return user != null;
        }

        public async Task<Usuario> LoginAsync(LoginViewModel vm)
        {
            string passwordEncrypt = PasswordEncryption.Encrypt(vm.Password);
            Usuario users = await _context.Set<Usuario>().FirstOrDefaultAsync(x => x.Email == vm.Email && x.Password == passwordEncrypt);
            return users;
        }

        public async Task<Usuario> ChangePassword(UsuarioSaveViewModel usuario)
        {
            Usuario user = await _context.Set<Usuario>().FirstOrDefaultAsync(u => u.Email == usuario.Email);
            return user;
        }
    }
}
