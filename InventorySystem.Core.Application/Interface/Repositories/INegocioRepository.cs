﻿using InventorySystem.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Application.Interface.Repositories
{
    public interface INegocioRepository: IGenericRepository<Negocios>
    {
        Task<bool> GetByNombre(string nombre);
    }
}
