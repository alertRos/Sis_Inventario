using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Application.ViewModel.Cliente
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; } 
        public string Cedula { get; set; } 
        public string Telefono { get; set; }
        public string AtendidoPor { get; set; }
        public string Negocio { get; set; }

    }
}
