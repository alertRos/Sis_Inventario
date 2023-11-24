using System;
using System.Collections.Generic;

namespace SisInventario.Models;

public partial class Categorias
{
    public int Id { get; set; }

    public string Categoria { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
