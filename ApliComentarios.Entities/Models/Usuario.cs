using ApiComentarios.Models;
using System.Collections.Generic;

namespace Models
{
    public class UsuarioInfo
    {
        public UsuarioInfo() 
        {
            Comentarios= new HashSet<Comentario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Comentario> Comentarios { get; set; }
    }
}
