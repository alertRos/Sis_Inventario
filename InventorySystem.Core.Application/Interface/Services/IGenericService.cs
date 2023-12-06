using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Application.Interface.Services
{
    public interface IGenericService<SaveViewModel, ViewModel>
        where SaveViewModel : class
        where ViewModel : class
    {
        Task<SaveViewModel> Update(SaveViewModel vm);
        Task<SaveViewModel> Add(SaveViewModel vm);
        Task<SaveViewModel> GetById(int id);
        Task<List<ViewModel>> GetAllViewModel();
        Task<SaveViewModel> Delete(int id);

    }
}
