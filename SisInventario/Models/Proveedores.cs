using System;
using System.Collections.Generic;

namespace SisInventario.Models;

public partial class Proveedores
{
    public int Id { get; set; }

    public string Proveedor { get; set; } = null!;

    public string? Direccion { get; set; }

    public string Telefono { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
