using InventorySystem.Core.Application.ViewModel.Negocio;
using InventorySystem.Core.Application.ViewModel.Usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Application.ViewModel.Representante
{
    public class RepresentanteSaveViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [Required(ErrorMessage = "La cedula es requerida")]
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public int IdUsuario { get; set; }
        public int IdNegocio { get; set; }
        public UsuarioSaveViewModel? usuario { get; set; } 
        public NegocioSaveViewModel? negocio { get; set; }
        public List<UsuarioViewModel>? usuarioViewModels { get; set; }
    }
}
