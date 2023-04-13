using ApiComentarios.Models;

namespace ApiComentarios.Repositories.Comments
{
    public class RepositoryComment : Repository<Comentario, AplicationDbContext>
    {
        public RepositoryComment(AplicationDbContext context) : base(context)
        {
        }
    }
}
