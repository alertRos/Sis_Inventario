using InventorySystem.Core.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Application.Interface.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailRequest request);
    }
}
