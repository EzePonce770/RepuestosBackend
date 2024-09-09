using AutoMapper;
using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Utils
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<FacturaDTO,Factura>().ReverseMap();
            CreateMap<FacturaCreateDTO, Factura>().ReverseMap();
            CreateMap<DetalleFacturaDTO,Detallefactura>().ReverseMap();
            CreateMap<MarcaDTO,Marca>().ReverseMap();
            CreateMap<RepuestoDTO,Repuesto>().ReverseMap();
            CreateMap<DetalleFacturaDTO, Detallefactura>().ReverseMap();
        }
    }
}
