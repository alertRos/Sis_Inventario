using InventorySystem.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Domain.Entities
{
    public class Representante:AuditableBaseEntity
    {
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public Usuario Usuario { get; set; }
        public int IdUsuario { get; set; }
        public Negocios Negocio { get; set; }
        public int IdNegocio { get; set; }
    }
}
