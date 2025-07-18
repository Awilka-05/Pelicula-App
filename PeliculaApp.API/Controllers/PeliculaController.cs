using Microsoft.AspNetCore.Mvc;
using PeliculaApp.Application.Services;
using PeliculaApp.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PeliculaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly IPeliculaService _servicio;

        public PeliculaController(IPeliculaService servicio)
        {
            _servicio = servicio;
        }
        // GET: api/<PeliculaController>
        [HttpGet]
        public IActionResult Get()
        {
            var peliculas = _servicio.ObtenerTodas();
            return Ok(peliculas);
        }

        // GET api/<PeliculaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pelicula = _servicio.ObtenerPorId(id);
            if (pelicula == null)
                return NotFound();

            return Ok(pelicula);
        }

        // POST api/<PeliculaController>
        [HttpPost]
        public IActionResult Post([FromBody] Pelicula pelicula)
        {
            _servicio.Crear(pelicula);
            return Ok();
        }

        // PUT api/<PeliculaController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Pelicula pelicula)
        {
            _servicio.Actualizar(pelicula);
            return Ok();
        }

        // DELETE api/<PeliculaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _servicio.Eliminar(id);
            return Ok();
        }

    }
}
