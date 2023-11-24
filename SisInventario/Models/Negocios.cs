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

    public int IdRepresentante { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual Cliente IdRepresentanteNavigation { get; set; } = null!;
}
