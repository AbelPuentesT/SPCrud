using Core.Entities;

namespace SPEFBlazorApp1.Services
{
    public interface IPeliculaService
    {
        Task<IEnumerable<Pelicula>> GetAllPeliculas();
    }
}