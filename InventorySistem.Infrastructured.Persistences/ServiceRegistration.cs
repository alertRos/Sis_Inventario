using InventorySystem.Infrastructured.Persistences.Repositories;
using InventorySystem.Core.Application.Interface.Repositories;
using InventorySystem.Infrastructured.Persistences.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySistem.Infrastructured.Persistences
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InventarioContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("InventorySystem"),
                m => m.MigrationsAssembly(typeof(InventarioContext).Assembly.FullName));
            });
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<INegocioRepository, NegocioRepository>();
            services.AddTransient<IProductoRepository, ProductoRepository>();
            services.AddTransient<IMarcaRepository, MarcaRepository>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<IProveedorRepository, ProveedorRepository>();
            services.AddTransient<IRepresentanteRepository, RepresentanteRepository>();

        }
    }
}
