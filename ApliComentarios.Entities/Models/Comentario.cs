using ApiComentarios.Abtractions;
using System;
using System.ComponentModel.DataAnnotations;

namespace ApiComentarios.Models
{
    public class Comentario : IEntity
    {
        public int id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Creador { get; set; }
        [Required]
        public string Texto { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
    }
}
