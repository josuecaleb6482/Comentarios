using ApiComentarios.Models;

namespace ApiComentarios.Repository
{
    public class ComentarioRepository : Repository<Comentario, AplicationDbContext>
    {
        public ComentarioRepository(AplicationDbContext context) : base(context)
        {
        }
    }
}
