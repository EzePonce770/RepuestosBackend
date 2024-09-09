using AutoMapper;
using Models;
using Models.DTO;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RepuestosService : IRepuestosService
    {
        private readonly IRepuestoRepository _repository;
        private readonly IMapper _mapper;

        public RepuestosService(IRepuestoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public RepuestoDTO Create(RepuestoDTO repuesto)
        {
            var rep = _mapper.Map<Repuesto>(repuesto);
            var result = _repository.Create(rep).Result;
            return _mapper.Map<RepuestoDTO>(result);    
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id).Result;
        }

        public List<RepuestoDTO> GetAll()
        {
            var result = _repository.GetAll().Result;
            return _mapper.Map<List<RepuestoDTO>>(result);
        }

        public RepuestoDTO GetbyId(int id)
        {
            var result = _repository.GetbyId(id).Result;
            return _mapper.Map<RepuestoDTO>(result);
        }

        public RepuestoDTO Update(RepuestoDTO repuesto)
        {
            var repmap = _mapper.Map<Repuesto>(repuesto);
            var response = _repository.Update(repmap).Result;
            return _mapper.Map<RepuestoDTO>(response);
        }
    }
}
