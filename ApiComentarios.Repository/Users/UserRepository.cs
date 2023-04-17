using Models;

namespace ApiComentarios.Repositories.Users
{
    public class UserRepository : Repository<User, AplicationDbContext>
    {
        public UserRepository(AplicationDbContext context) : base(context)
        {
        }
    }
}
