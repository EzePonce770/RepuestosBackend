using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IFacturasRepository
    {
        public Task<Factura> Create(Factura factura);
        public Task<List<Factura>> GetAll();
        public Task<Factura> GetbyId(int id);

    }
}
