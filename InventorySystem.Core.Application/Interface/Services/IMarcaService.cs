using InventorySystem.Core.Application.ViewModel.Marca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Application.Interface.Services
{
    public interface IMarcaService:IGenericService<MarcaSaveViewModel, MarcaViewModel>
    {
    }
}
