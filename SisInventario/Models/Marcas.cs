using System;
using System.Collections.Generic;

namespace SisInventario.Models;

public partial class Marcas
{
    public int Id { get; set; }

    public string Marca { get; set; } = null!;

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
