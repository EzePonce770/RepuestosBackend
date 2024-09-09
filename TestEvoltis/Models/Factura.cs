using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Factura
    {
        public Factura()
        {
            Detallefacturas = new HashSet<Detallefactura>();
        }

        public int IdFactura { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }

        public virtual ICollection<Detallefactura> Detallefacturas { get; set; }
    }
}
