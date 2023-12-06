using InventorySystem.Core.Application.ViewModel.Usuario;
using Microsoft.AspNetCore.Http;
using InventorySystem.Core.Application.Helper;

namespace InventorySystem.Middlewares
{
    public class ValidateUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ValidateUserSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public bool hasUser()
        {
            UsuarioViewModel usersViewModel = _httpContextAccessor.HttpContext.Session.Get<UsuarioViewModel>("user");
            if (usersViewModel == null)
            {
                return false;
            }
            return true;

        }
        public bool hasAdmin()
        {
            UsuarioViewModel usersViewModel = _httpContextAccessor.HttpContext.Session.Get<UsuarioViewModel>("user");
            if (usersViewModel == null)
            {
                return false;
            }
            if (usersViewModel.RoleName == "Administrador")
            {
                return true;
            }
            return false;
        }

        public bool SuperUser()
        {
            UsuarioViewModel usersViewModel = _httpContextAccessor.HttpContext.Session.Get<UsuarioViewModel>("user");
            if (usersViewModel == null)
            {
                return false;
            }
            if (usersViewModel.RoleName == "SuperUser")
            {
                return true;
            }
            return false;
        }
    }
}
