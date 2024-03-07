using Microsoft.AspNetCore.Mvc;
using Sales.Infraestructure.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioDb _usuarioDb;
        public UsuarioController(IUsuarioDb usuarioDb)
        {
            this._usuarioDb = usuarioDb;
        }
        // GET: api/<UsuarioController>
        [HttpGet]
        public IActionResult GetUsuario()
        {
            var usuarios = this._usuarioDb.GetAll();
            return Ok(usuarios);
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
