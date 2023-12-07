using InventorySystem.Core.Application.ViewModel.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Application.ViewModel.Usuario
{
    public class UsuarioSaveViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }  
        public string Password { get; set; }
        [Compare(nameof(Password), ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
    }
}
