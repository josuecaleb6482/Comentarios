using ApiComentarios.DataAccess.Configuretions;
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
        public DbSet<Comments> Comentarios { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
