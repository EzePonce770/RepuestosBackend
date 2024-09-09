using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class RepuestoDTO
    {
        public int IdRepuestos { get; set; }
        public string NombreRepuesto { get; set; } = null!;
        public int IdMarca { get; set; }
        public double Precio { get; set; }
        public MarcaDTO IdMarcaNavigation { get; set; }
    }
}
