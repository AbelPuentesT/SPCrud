

using Core.Entities;

namespace SPEFBlazorApp1.Services
{
    public class PeliculaService : IPeliculaService
    {
        private readonly HttpClient _httpClient;
        public PeliculaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Pelicula>> GetAllPeliculas()
        {
            var peliculas = await _httpClient.GetFromJsonAsync<IEnumerable<Pelicula>>($"api/Pelicula");
            return peliculas;
        }
    }
}
