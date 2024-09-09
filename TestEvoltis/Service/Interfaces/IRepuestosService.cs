using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IRepuestosService
    {
        List<RepuestoDTO> GetAll();
        RepuestoDTO GetbyId(int id);
        RepuestoDTO Create(RepuestoDTO repuesto);
        RepuestoDTO Update(RepuestoDTO repuesto);
        bool Delete(int id);
    }
}
