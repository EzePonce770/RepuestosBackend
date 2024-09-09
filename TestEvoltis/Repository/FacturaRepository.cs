using Microsoft.EntityFrameworkCore;
using Models;
using Repository.Interfaces;
using Repository.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class FacturaRepository : IFacturasRepository
    {
        private readonly repuestosContext _context;

        public FacturaRepository(repuestosContext context)
        {
            _context = context;
        }

        public async Task<Factura> Create(Factura factura) 
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.IdCliente == factura.IdCliente);
            if (cliente == null)
            {
                throw new BadRequestException($"El cliente con ID {factura.IdCliente} no existe.");
            }
            factura.Fecha = DateTime.Now;

            factura.Detallefacturas = new List<Detallefactura>();
            double monto = 0;

            foreach (var detalle in factura.Detallefacturas)
            {
                var repuestoExiste = await _context.Repuestos.AnyAsync(r => r.IdRepuestos == detalle.IdRepuesto);
                if (!repuestoExiste)
                {
                    throw new BadRequestException($"El repuesto con ID {detalle.IdRepuesto} no existe.");
                }

                monto += detalle.Cantidad * detalle.IdRepuestoNavigation.Precio;

                detalle.IdFactura = factura.IdFactura;

                factura.Detallefacturas.Add(detalle);
            }

            _context.Facturas.Add(factura);
            await _context.SaveChangesAsync();


            return factura;
        }

        public async Task<List<Factura>> GetAll()
        {
            var listFacturas = await _context.Facturas.Include(x => x.Detallefacturas).ToListAsync();
            return listFacturas;
        }

        public Task<Factura> GetbyId(int id)
        {
            var factura = _context.Facturas.Include(f => f.Detallefacturas)
                                           .FirstOrDefaultAsync(f => f.IdFactura == id);
            return factura;
        }
    }
}
