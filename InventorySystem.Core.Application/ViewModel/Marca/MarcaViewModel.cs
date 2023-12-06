using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Application.ViewModel.Marca
{
    public class MarcaViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Email { get; set; }

        public string? Telefono { get; set; }
        public int CountProductos { get; set; }
    }
}
