using ApiComentarios.Abtractions;
using Models;
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
        public int IdUsuario { get; set; }
        [Required]
        public string Texto { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }

        public virtual UsuarioInfo IdUserInfo { get; set; }
    }
}
