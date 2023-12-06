using InventorySystem.Core.Domain.Common;
using System;
using System.Collections.Generic;

namespace InventorySystem.Core.Domain.Entities;

public partial class Proveedores : AuditableBaseEntity
{
    public string? Direccion { get; set; }

    public string Telefono { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
