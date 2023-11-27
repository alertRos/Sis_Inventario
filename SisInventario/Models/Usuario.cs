using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisInventario.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;
    public string Password { get; set; }

    [Compare(nameof(Password), ErrorMessage = "Las contraseñas no coinciden")]
    [NotMapped]
    public string ConfirmPassword { get; set; }

    public string Email { get; set; } = null!;
    public int IdRole { get; set; }
    public int IdNegocio { get; set; }
    public virtual Negocios Negocios { get; set; }
    public virtual Role role { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
