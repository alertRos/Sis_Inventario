using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Application.ViewModel.Marca
{
    public class MarcaSaveViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
    }
}
