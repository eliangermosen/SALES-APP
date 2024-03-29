using Microsoft.AspNetCore.Mvc;
using Sales.AppServices.Contract;
using Sales.AppServices.DTOs.Venta;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaService _ventaService;

        public VentaController(IVentaService ventaService)
        {
            _ventaService = ventaService;
        }

        // GET: api/<VentaController>
        [HttpGet("byUser")]
        public async Task<IActionResult> GetSaleByUser(int userId)
        {
            var result = await this._ventaService.GetByVendedor(userId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/<VentaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this._ventaService.GetAll();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET api/<VentaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this._ventaService.GetById(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // POST api/<VentaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VentaPostDTO value)
        {
            var result = await this._ventaService.Save(value);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // PUT api/<VentaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] VentaPutDTO value)
        {
            var result = await this._ventaService.Update(id, value);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // DELETE api/<VentaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
