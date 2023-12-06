using InventorySystem.Core.Domain.Common;
using System;
using System.Collections.Generic;

namespace InventorySystem.Core.Domain.Entities;

public partial class Categorias:AuditableBaseEntity
{
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
