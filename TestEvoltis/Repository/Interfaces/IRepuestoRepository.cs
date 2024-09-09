using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRepuestoRepository
    {
        Task<List<Repuesto>> GetAll();
        Task<Repuesto> GetbyId(int id);
        Task<Repuesto> Create(Repuesto repuesto);
        Task<Repuesto> Update(Repuesto repuesto);
        Task<bool> Delete(int id);
    }
}
