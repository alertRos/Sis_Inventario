using InventorySystem.Core.Domain.Common;
using System;
using System.Collections.Generic;

namespace InventorySystem.Core.Domain.Entities;

public partial class Negocios : AuditableBaseEntity
{
    public string Telefono { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Email { get; set; } = null!;

    public ICollection<Producto> Productos { get; set; } = new List<Producto>();

    public ICollection<Representante> Representantes { get; set; } = new List<Representante>();

}
