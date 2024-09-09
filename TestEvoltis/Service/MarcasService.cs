using AutoMapper;
using Models;
using Models.DTO;
using Repository;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MarcasService : IMarcasService
    {
        private readonly IMarcasRepository _repository;
        private readonly IMapper _mapper;
        public MarcasService(IMarcasRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<MarcaDTO> GetAll()
        {
            List<Marca> lista = _repository.GetAll().Result;
            return _mapper.Map<List<MarcaDTO>>(lista);
        }

        public MarcaDTO GetById(int Id)
        {
            Marca marca = _repository.GetById(Id).Result;
            return _mapper.Map<MarcaDTO>(marca);
        }
    }
}
