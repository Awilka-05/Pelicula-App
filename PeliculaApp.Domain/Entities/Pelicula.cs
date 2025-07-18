using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeliculaApp.Domain.Entities
{
  
    [Table("Pelicula")]
    public class Pelicula
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public int Estreno { get; set; }
        public string Genero { get; set; }

        [Required]
        public string Director { get; set; }

        public int Calificacion { get; set; }

        public string CartelUrl { get; set; }

        public string TrailerUrl { get; set; }
    }
    
}
