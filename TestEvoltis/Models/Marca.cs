using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Marca
    {
        public Marca()
        {
            Repuestos = new HashSet<Repuesto>();
        }

        public int IdMarca { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Repuesto> Repuestos { get; set; }
    }
}
