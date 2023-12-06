using InventorySystem.Core.Application.ViewModel.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Application.Interface.Services
{
    public interface IUsuarioService:IGenericService<UsuarioSaveViewModel, UsuarioViewModel>
    {
        Task<bool> GetEmail(UsuarioSaveViewModel vm);
        Task<UsuarioViewModel> Login(LoginViewModel vm);
    }
}
