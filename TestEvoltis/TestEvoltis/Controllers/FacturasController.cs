using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models;
using Service.Interfaces;

namespace TestEvoltis.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly IFacturasService _facturasService;
        public FacturasController(IFacturasService facturasService)
        {
            _facturasService = facturasService;
        }

        [HttpPost]
        public IActionResult Create(FacturaCreateDTO factura)
        {
            return Ok(_facturasService.Create(factura));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_facturasService.GetAll());
        }

        [HttpGet]
        public IActionResult GetbyId(int id)
        {
            return Ok(_facturasService.GetbyId(id));
        }


    }
}
