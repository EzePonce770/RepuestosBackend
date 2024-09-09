using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> Create(Cliente cliente);
        Task<bool> Delete(int id);
        Task<List<Cliente>> GetAll();
        Task<Cliente> GetbyId(int id);
        Task<Cliente> Update(Cliente cliente);
    }
}
