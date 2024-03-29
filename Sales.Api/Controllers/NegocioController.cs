using Microsoft.AspNetCore.Mvc;
using Sales.AppServices.Contract;
using Sales.AppServices.DTOs.Negocio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NegocioController : ControllerBase
    {
        private readonly INegocioService _negocioService;

        public NegocioController(INegocioService negocioService)
        {
            _negocioService = negocioService;
        }

        // GET: api/<NegocioController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this._negocioService.GetAll();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET api/<NegocioController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this._negocioService.GetById(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // POST api/<NegocioController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NegocioPostDTO value)
        {
            var result = await this._negocioService.Save(value);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);

        }

        // PUT api/<NegocioController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] NegocioPutDTO value)
        {
            var result = await this._negocioService.Update(id, value);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // DELETE api/<NegocioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
