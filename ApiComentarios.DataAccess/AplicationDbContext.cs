using ApiComentarios.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiComentarios
{
    public class AplicationDbContext : DbContext
    {
        
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) 
            : base(options)
        {
        }
        public DbSet<Comentario> Comentarios { get; set; }
    }
}
