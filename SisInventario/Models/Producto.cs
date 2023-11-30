﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisInventario.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Precio { get; set; }

    public string Descripcion { get; set; } = null!;

    public int IdCategoria { get; set; }

    public int IdMarca { get; set; }

    public DateTime? FechaCaducidad { get; set; }

    public string AreaUbicacion { get; set; } = null!;

    public int Stock { get; set; }

    public int IdProveedor { get; set; }
    public int IdNegocio { get; set; }
    public Negocios Negocios { get; set; }


    //Not Mapped
    [NotMapped]
    public string NombreCategoria { get; set; } = null!;
    [NotMapped]
    public string NombreMarca { get; set; } = null!;
    [NotMapped]
    public string NombreProveedor { get; set; } = null!;
    public virtual Categorias IdCategoriaNavigation { get; set; } = null!;

    public virtual Marcas IdMarcaNavigation { get; set; } = null!;

    public virtual Proveedores IdProveedorNavigation { get; set; } = null!;
}
