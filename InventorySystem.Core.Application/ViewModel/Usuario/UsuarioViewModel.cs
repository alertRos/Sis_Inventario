﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Application.ViewModel.Usuario
{
    public class UsuarioViewModel
    {
       public int Id { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }    
        public string Email { get; set; }
        public string RoleName { get; set; }
        public int IdNegocio { get; set; }
    }
}
