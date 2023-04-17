using ApiComentarios.Abtractions.Interfaces;
using Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ApiComentarios.Models
{
    public class Comments : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Texto { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }

        public virtual User UserInfo { get; set; }
    }
}
