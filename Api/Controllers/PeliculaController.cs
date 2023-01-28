using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly PruebaSpnetContext _PruebaSpnetContext;
        public PeliculaController(PruebaSpnetContext pruebaSpnetContext)
        {
            _PruebaSpnetContext = pruebaSpnetContext;   
        }
        [HttpGet]
        public async Task<IActionResult>GetAllPeliculas() 
        {

            var peliculas = await _PruebaSpnetContext.Peliculas.FromSql($"ConsultarPelicula").ToListAsync();
            return Ok(peliculas);
        }
        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPelicula(int id)
        {
            var pelicula = await _PruebaSpnetContext.Peliculas.FromSql($"ConsultarPeliculaId {id}").ToListAsync();
            if (pelicula.Count==0)
            {
                return NotFound();
            }
            var peli = pelicula.Single();
            return Ok(peli);
                        
        }

        [HttpPost]
        public async Task<IActionResult> PostPelicula(Pelicula pelicula)
        {
            var peliculaNeva= await _PruebaSpnetContext.Database.ExecuteSqlAsync
                ($"CrearPelicula  @Nombre={pelicula.Nombre},@Genero= {pelicula.Genero}");
            return Ok(pelicula);
        }
        [HttpPut]
        public async Task<IActionResult> PutPelicula(int id, Pelicula pelicula)
        {
            
            var peliculaExistente= await _PruebaSpnetContext.Database.ExecuteSqlAsync($"ActualizarPelicula {id},{pelicula.Nombre},{pelicula.Genero}");
            return Ok(pelicula);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePelicula(int id)
        {
            var peliculaExistente = await _PruebaSpnetContext.Database.ExecuteSqlAsync($"EliminarPelicula {id}");
            return Ok();
        }
    }
}
