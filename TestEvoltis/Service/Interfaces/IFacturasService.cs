using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IFacturasService
    {
        public Factura Create(FacturaCreateDTO factura);
        public List<Factura> GetAll();
        public FacturaDTO GetbyId(int id);
    }
}
