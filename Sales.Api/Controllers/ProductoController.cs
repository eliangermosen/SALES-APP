using Microsoft.AspNetCore.Mvc;
using Sales.Infraestructure.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoDb _productoDb;

        public ProductoController(IProductoDb productoDb)
        {
            _productoDb = productoDb;
        }

        // GET: api/<ProductoController>
        [HttpGet("byCategory")]
        public IActionResult GetProductsByCategory(int category)
        {
            var result = _productoDb.GetProductsByCategories(category);
            return Ok(result);
        }

        // GET: api/<ProductoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
