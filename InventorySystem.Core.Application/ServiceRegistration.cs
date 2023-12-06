using InventorySystem.Core.Application.Interface.Services;
using InventorySystem.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<INegocioService, NegocioService>();
            services.AddScoped<IProveedorService, ProveedorService>();
            services.AddScoped<ICategoryService, CategoriaService>();
            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<IMarcaService, MarcaService>();
            services.AddTransient<IRepresentanteService, RepresentanteService>();

        }
    }
}
