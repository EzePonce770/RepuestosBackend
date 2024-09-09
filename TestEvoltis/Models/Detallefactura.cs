using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Detallefactura
    {
        public int IdDetalleFactura { get; set; }
        public int IdFactura { get; set; }
        public int IdRepuesto { get; set; }
        public int Cantidad { get; set; }

        public virtual Factura IdFacturaNavigation { get; set; } = null!;
        public virtual Repuesto IdRepuestoNavigation { get; set; } = null!;
    }
}
