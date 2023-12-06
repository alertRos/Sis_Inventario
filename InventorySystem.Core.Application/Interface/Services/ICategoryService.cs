using InventorySystem.Core.Application.ViewModel.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Application.Interface.Services
{
    public interface ICategoryService:IGenericService<CategoriaSaveViewModel, CategoriaViewModel>
    {
    }
}
