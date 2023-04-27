using System.ComponentModel.DataAnnotations;
using System;
using Mapster;
using ApiComentarios.Models;

namespace ApiComentarios.DTOSs
{
    public class CommentDTO : IRegister
    {
        /// <summary>
        /// Identificador
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Título del post
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// Usuario que lo creo
        /// </summary>
        [Required]
        public int UserId { get; set; }
        /// <summary>
        /// Texto o contenido del post
        /// </summary>
        [Required]
        public string Text { get; set; }
        /// <summary>
        /// Fecha en que se creó o fue su ultima actualización
        /// </summary>
        [Required]
        public DateTime FechaCreacion { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Comments, CommentDTO>()
                .Map(d => d.Id, s => s.Id)
                .Map(d => d.UserId, s => s.UserId)
                .Map(d => d.Text, s => s.Text)
                .Map(d => d.Title, s => s.Title)
                .Map(d => d.FechaCreacion, s => s.FechaCreacion)
                .IgnoreNullValues(true);
        }
    }
}
