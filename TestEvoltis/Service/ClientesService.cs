using Models;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ClientesService : IClienteService
    {
        private readonly IClienteRepository _repository;
        public ClientesService(IClienteRepository repository)
        {
            _repository = repository;
        }
        public Cliente Create(Cliente cliente)
        {
            return _repository.Create(cliente).Result;
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id).Result;
        }

        public List<Cliente> GetAll()
        {
            return _repository.GetAll().Result;
        }

        public Cliente GetbyId(int id)
        {
            return _repository.GetbyId(id).Result;
        }

        public Cliente Update(Cliente cliente)
        {
            return _repository.Update(cliente).Result;  
        }
    }
}
