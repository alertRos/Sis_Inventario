using InventorySystem.Core.Application.Interface.Services;
using InventorySystem.Core.Application.ViewModel.Usuario;
using InventorySystem.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Application.Interface.Repositories
{
    public interface IUsuarioRepository:IGenericRepository<Usuario>
    {
        Task<Usuario> LoginAsync(LoginViewModel vm);
        Task<bool> GetEmail(UsuarioSaveViewModel vm);
    }
}
