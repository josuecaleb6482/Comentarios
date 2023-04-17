using System.ComponentModel.DataAnnotations;
using System;

namespace ApiComentarios.DTOSs
{
    public class ComentarioDTO
    {
        [Required]
        public string Titulo { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Texto { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }

    }
}
