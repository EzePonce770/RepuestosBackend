using Microsoft.AspNetCore.Mvc;
using Models;
using Service.Interfaces;

namespace TestEvoltis.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        /// <summary>
        /// Crea un cliente , ingresando los datos por parametro.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            return Ok(_clienteService.Create(cliente));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _clienteService.Delete(id);
            return Ok(true);
        }

        [HttpPost]
        public IActionResult Update(Cliente cliente)
        {
            return Ok(_clienteService.Update(cliente));
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(_clienteService.GetbyId(id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_clienteService.GetAll());
        }
    }
}
