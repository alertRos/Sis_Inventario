using InventorySystem.Core.Application.ViewModel.Negocio;
using InventorySystem.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Application.Interface.Services
{
    public interface INegocioService:IGenericService<NegocioSaveViewModel, NegocioViewModel>
    {
        Task<bool> GetByNombre(string nombre);
    }
}
