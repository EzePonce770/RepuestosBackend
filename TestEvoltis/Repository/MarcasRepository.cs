using Microsoft.EntityFrameworkCore;
using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MarcasRepository : IMarcasRepository
    {
        private readonly repuestosContext _context;
        public MarcasRepository(repuestosContext context)
        {
            _context = context;
        }

        public async Task<List<Marca>> GetAll()
        {
            var listMarcas = await _context.Marcas.ToListAsync();
            return listMarcas;
        }

        public async Task<Marca> GetById(int Id)
        {
            try
            {
                Marca marca = await _context.Marcas.FirstOrDefaultAsync(x => x.IdMarca == Id);
                return marca;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
