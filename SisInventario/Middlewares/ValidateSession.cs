using Microsoft.AspNetCore.Http;
using SisInventario.Models;
using SisInventario.Helper;

namespace SisInventario.Middlewares
{
    public class ValidateSession
    {
        private readonly IHttpContextAccessor _httpContext;
        public ValidateSession(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public bool HasUser()
        {
            Usuario user = _httpContext.HttpContext.Session.Get<Usuario>("user");
            if (user == null)
            {
                return false;
            }

            return true;
        }
    }
}
