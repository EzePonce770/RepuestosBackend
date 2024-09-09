using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Repuesto
    {
        public Repuesto()
        {
            Detallefacturas = new HashSet<Detallefactura>();
        }

        public int IdRepuestos { get; set; }
        public string NombreRepuesto { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int IdMarca { get; set; }
        public double Precio { get; set; }

        public virtual Marca IdMarcaNavigation { get; set; } = null!;
        public virtual ICollection<Detallefactura> Detallefacturas { get; set; }
    }
}
