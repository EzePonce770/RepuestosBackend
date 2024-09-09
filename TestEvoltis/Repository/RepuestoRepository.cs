using Microsoft.EntityFrameworkCore;
using Models;
using Repository.Interfaces;
using Repository.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepuestoRepository : IRepuestoRepository
    {
        private readonly repuestosContext _context;
        public RepuestoRepository(repuestosContext context)
        {
            _context = context;
        }

        public async Task<Repuesto> Create(Repuesto repuesto)
        {
            _context.Repuestos.Add(repuesto);   
            await _context.SaveChangesAsync();
            return repuesto;
        }

        public async Task<bool> Delete(int id)
        {
            var repuesto = GetbyId(id).Result;

            if (repuesto == null)
            {
                throw new BadRequestException($"No existe el objeto con el id {id}");
            }

            _context.Repuestos.Remove(repuesto);
            await _context.SaveChangesAsync();  
            return true;

        }

        public async Task<List<Repuesto>> GetAll()
        {
            var listRepuestos = await _context.Repuestos.Include(x => x.IdMarcaNavigation).ToListAsync();
            return listRepuestos;
        }

        public Task<Repuesto> GetbyId(int id)
        {
            var repuesto = _context.Repuestos.Include(x => x.IdMarcaNavigation)
                                             .FirstOrDefaultAsync(x => x.IdRepuestos == id);
            return repuesto;
        }

        public async Task<Repuesto> Update(Repuesto repuesto)
        {
            _context.Entry(repuesto).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return GetbyId(repuesto.IdRepuestos).Result;

        }
    }   
}
