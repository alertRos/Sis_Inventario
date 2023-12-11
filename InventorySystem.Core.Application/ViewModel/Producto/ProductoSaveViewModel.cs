using InventorySystem.Core.Application.ViewModel.Categoria;
using InventorySystem.Core.Application.ViewModel.Marca;
using InventorySystem.Core.Application.ViewModel.Proveedor;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string? ImgUrl { get; set; }
        public IFormFile? ImgFile { get; set; }

        public string Descripcion { get; set; } = null!;

        [Required(ErrorMessage = "Seleccione una categoría.")]
        public int IdCategoria { get; set; } 

        [Required(ErrorMessage = "Seleccione una marca.")]
        public int IdMarca { get; set; }


        public DateTime? FechaCaducidad { get; set; }

        public string AreaUbicacion { get; set; } = null!;

        public int Stock { get; set; }

        [Required(ErrorMessage = "Seleccione un proveedor.")]
        public int IdProveedor { get; set; }
        public int IdNegocio { get; set; }
        public List<CategoriaViewModel>? categoriaViewModels { get; set; }
        public List<MarcaViewModel>? marcaViewModels { get; set; }
        public List<ProveedorViewModel>? proveedorSaveViews { get; set; }
    }
}
