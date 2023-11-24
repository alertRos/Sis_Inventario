using System;
using System.Collections.Generic;

namespace SisInventario.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Cedula { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public int IdUsuario { get; set; }

    public int IdNegocio { get; set; }

    public virtual Negocios IdNegocioNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Negocios> Negocio { get; set; } = new List<Negocios>();
}
