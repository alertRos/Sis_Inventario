using InventorySystem.Core.Domain.Common;
using System;
using System.Collections.Generic;

namespace InventorySystem.Core.Domain.Entities;

public partial class Marcas : AuditableBaseEntity
{
    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
