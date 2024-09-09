using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class FacturaCreateDTO
    {
        public int IdCliente { get; set; }
        public List<DetalleFacturaDTO> Detalles { get; set; }
    }
}
