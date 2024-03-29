using Microsoft.AspNetCore.Mvc;
using Sales.AppServices.Contract;
using Sales.AppServices.DTOs.DetalleVenta;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleVentaController : ControllerBase
    {
        private readonly IDetalleVentaService _detalleVentaService;

        public DetalleVentaController(IDetalleVentaService detalleVentaService)
        {
            _detalleVentaService = detalleVentaService;
        }

        // GET: api/<DetalleVentaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this._detalleVentaService.GetAll();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET api/<DetalleVentaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this._detalleVentaService.GetById(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // POST api/<DetalleVentaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DetalleVentaPostDTO value)
        {
            var result = await this._detalleVentaService.Save(value);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // PUT api/<DetalleVentaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DetalleVentaPutDTO value)
        {
            var result = await this._detalleVentaService.Update(id, value);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // DELETE api/<DetalleVentaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
