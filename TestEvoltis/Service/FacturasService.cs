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
    public class FacturasService : IFacturasService
    {
        private readonly IFacturasRepository _repository;
        private readonly IMapper _mapper;
        public FacturasService(IFacturasRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public Factura Create(FacturaCreateDTO facturaDTO)
        {
            Factura factura = _mapper.Map<Factura>(facturaDTO);
            return _repository.Create(factura).Result;
        }

        public List<Factura> GetAll()
        {
            List<Factura> listFactura = _repository.GetAll().Result;
            return listFactura;
        }

        public FacturaDTO GetbyId(int id)
        {
            Factura factura = _repository.GetbyId(id).Result;
            return _mapper.Map<FacturaDTO>(factura);
        }
    }
}
