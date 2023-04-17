using System.ComponentModel.DataAnnotations;
using System;

namespace ApiComentarios.DTOSs
{
    public class CommentDTO
    {
        /// <summary>
        /// Título del post
        /// </summary>
        [Required]
        public string Titulo { get; set; }
        /// <summary>
        /// Usuario que lo creo
        /// </summary>
        [Required]
        public int UserId { get; set; }
        /// <summary>
        /// Texto o contenido del post
        /// </summary>
        [Required]
        public string Texto { get; set; }
        /// <summary>
        /// Fecha en que se creó o fue su ultima actualización
        /// </summary>
        [Required]
        public DateTime FechaCreacion { get; set; }

    }
}
