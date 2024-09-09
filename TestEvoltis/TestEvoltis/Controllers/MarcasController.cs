using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace TestEvoltis.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private readonly IMarcasService _marcasService;
        public MarcasController(IMarcasService marcasService)
        {
            _marcasService = marcasService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_marcasService.GetAll());
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(_marcasService.GetById(id));
        }
    }
}
