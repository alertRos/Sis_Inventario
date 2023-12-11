using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Application.ViewModel.Proveedor
{
    public class ProveedorSaveViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "El campo Nombre no puede tener más de 50 caracteres.")]
        public string Nombre { get; set; }

        [StringLength(100, ErrorMessage = "El campo Direccion no puede tener más de 100 caracteres.")]
        [DataType(DataType.MultilineText)]
        public string? Direccion { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es obligatorio.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El campo Teléfono debe tener 10 dígitos numéricos.")]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo Email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El campo Email no es valido")]
        [DataType(DataType.EmailAddress)]
        [StringLength(100, ErrorMessage = "El campo Email no puede tener más de 100 caracteres.")]
        public string Email { get; set; }

    }
}
