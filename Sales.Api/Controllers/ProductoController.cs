using Microsoft.AspNetCore.Mvc;
using Sales.AppServices.Contract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        // GET: api/<ProductoController>
        [HttpGet("byCategory")]
        public async Task<IActionResult> GetProductsByCategory(int category)
        {
            var result = await _productoService.GetProductsByCategories(category);

            if(!result.Success)
                return BadRequest(result);

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
