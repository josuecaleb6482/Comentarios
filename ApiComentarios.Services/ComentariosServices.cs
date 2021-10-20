using ApiComentarios.Models;
using ApiComentarios.Repository;

namespace ApiComentarios.Services
{
    public class ComentariosServices : Repository<Comentario, AplicationDbContext>
    {
        public ComentariosServices(AplicationDbContext context) : base(context)
        {
        }
    }
}
