using ApiComentarios.Abtractions.Interfaces;
using ApiComentarios.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User : IEntity
    {
        public User() 
        {
            Comentarios= new HashSet<Comments>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(25)]
        public string Rol { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public virtual ICollection<Comments> Comentarios { get; set; }
    }
}
