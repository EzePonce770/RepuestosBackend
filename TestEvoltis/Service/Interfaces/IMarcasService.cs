﻿using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IMarcasService
    {
        List<MarcaDTO> GetAll();
        MarcaDTO GetById(int Id);
    }
}
