using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Application.ViewModel.Producto
{
    public class ProductoSaveViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string ImgUrl { get; set; }

        public string Descripcion { get; set; } = null!;

        public int IdCategoria { get; set; }

        public int IdMarca { get; set; }

        public DateTime? FechaCaducidad { get; set; }

        public string AreaUbicacion { get; set; } = null!;

        public int Stock { get; set; }

        public int IdProveedor { get; set; }
        public int IdNegocio { get; set; }
    }
}
