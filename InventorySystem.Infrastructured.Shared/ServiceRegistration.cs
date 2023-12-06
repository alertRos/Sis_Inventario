using InventorySystem.Core.Application.Interface.Services;
using InventorySystem.Core.Domain.Settings;
using InventorySystem.Infrastructured.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Infrastructured.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IEmailService, EmailServices>();
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
        }
    }
}
