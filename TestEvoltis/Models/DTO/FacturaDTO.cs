using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class FacturaDTO
    {
        public int IdCliente { get; set; }
        public DateOnly Fecha { get; set; }
        public double Monto { get; set; }
        public List<DetalleFacturaDTO> Detalles { get; set; }
    }
}
