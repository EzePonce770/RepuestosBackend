using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Service.Interfaces;

namespace TestEvoltis.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RepuestosController : ControllerBase
    {
        private readonly IRepuestosService _repuestosService;
        public RepuestosController(IRepuestosService repuestosService)
        {
            _repuestosService = repuestosService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repuestosService.GetAll());
        }

        [HttpGet]
        public IActionResult GetbyId(int id)
        {
            return Ok(_repuestosService.GetbyId(id));
        }

        [HttpPost]
        public IActionResult Create(RepuestoDTO repuesto)
        {
            return Ok(_repuestosService.Create(repuesto));
        }

        [HttpPut]
        public IActionResult Update(RepuestoDTO repuesto)
        {
            return Ok(_repuestosService.Update(repuesto));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _repuestosService.Delete(id);
            return Ok(true);
        }
    }
}
