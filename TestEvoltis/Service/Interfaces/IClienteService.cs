using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IClienteService
    {
        Cliente Create(Cliente cliente);
        bool Delete(int id);
        List<Cliente> GetAll();
        Cliente GetbyId(int id);
        Cliente Update(Cliente cliente);
    }
}
