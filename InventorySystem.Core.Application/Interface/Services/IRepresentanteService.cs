using InventorySystem.Core.Application.ViewModel.Representante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Application.Interface.Services
{
    public interface IRepresentanteService:IGenericService<RepresentanteSaveViewModel, RepresentanteViewModel>
    {
        Task<bool> GetbyCedula(string cedula);
    }
}
