using System;
using System.Collections.Generic;

namespace SisInventario.Models;

public partial class Negocios
{
    public int Id { get; set; }

    public string Negocio { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Email { get; set; } = null!;

    public ICollection<Producto> Productos { get; set; } = new List<Producto>();

    public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

}
