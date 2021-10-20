using ApiComentarios.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiComentarios
{
    public class AplicationDbContext : DbContext
    {
        public DbSet<Comentario> Comentarios { get; set; }
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
        }
    }
}
