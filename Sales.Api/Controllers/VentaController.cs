using Microsoft.AspNetCore.Mvc;
using Sales.Infraestructure.Dao;
using Sales.Infraestructure.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        public readonly IVentaDb _ventaDB;

        public VentaController(IVentaDb ventaDB)
        {
            _ventaDB = ventaDB;
        }

        // GET: api/<VentaController>
        [HttpGet("byUser")]
        public IActionResult GetSaleByUser(int userId)
        {
            var result = _ventaDB.GetByVendedor(userId);
            return Ok(result);
        }

        // GET: api/<VentaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<VentaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VentaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<VentaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VentaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
