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
    public class ClienteRepository : IClienteRepository
    {
        private readonly repuestosContext _context;
        public ClienteRepository(repuestosContext context) 
        {
            _context = context;
        }

        public async Task<Cliente> Create(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<bool> Delete(int id)
        {
            var cliente = await GetbyId(id);

            if (cliente == null)
            {
                throw new BadRequestException($"No existe el objeto con el id {id}");
            }

            try
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) 
            {

                throw ex;
            }


            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Cliente>> GetAll()
        {
            var listClientes = await _context.Clientes.ToListAsync();
            return listClientes;
        }

        public Task<Cliente> GetbyId(int id)
        {
            var cliente = _context.Clientes.FirstOrDefaultAsync(x => x.IdCliente == id);
            return cliente;
        }

        public async Task<Cliente> Update(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return await GetbyId(cliente.IdCliente);
        }
    }
}
