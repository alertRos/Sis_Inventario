using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Application.ViewModel.Categoria
{
    public class CategoriaViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CountProductos { get; set; }
    }
}
