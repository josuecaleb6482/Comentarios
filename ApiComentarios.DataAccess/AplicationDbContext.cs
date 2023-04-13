using ApiComentarios.Models;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ApiComentarios
{
    public class AplicationDbContext : DbContext
    {

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<UsuarioInfo> UsuarioInfos { get; set; }
    }
}
