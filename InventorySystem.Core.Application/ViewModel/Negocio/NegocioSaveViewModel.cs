﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Application.ViewModel.Negocio
{
    public class NegocioSaveViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; } 
        public string Direccion { get; set; } 
        public string Email { get; set; }
    }
}
