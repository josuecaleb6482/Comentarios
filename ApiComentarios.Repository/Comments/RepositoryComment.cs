namespace ApiComentarios.Repositories.Comments
{
    public class RepositoryComment : Repository<Models.Comments, AplicationDbContext>
    {
        public RepositoryComment(AplicationDbContext context) : base(context)
        {
        }
    }
}
