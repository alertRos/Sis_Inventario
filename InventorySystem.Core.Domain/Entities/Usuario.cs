using InventorySystem.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventorySystem.Core.Domain.Entities;

public partial class Usuario : AuditableBaseEntity
{
    public string Password { get; set; }
    public string RoleName { get; set; }
    public string Email { get; set; } = null!;
    public List<Representante> Representantes { get; set;}

}
