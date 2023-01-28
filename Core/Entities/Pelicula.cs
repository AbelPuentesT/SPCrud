using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public  class Pelicula
{
    
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Genero { get; set; } = null!;
}
