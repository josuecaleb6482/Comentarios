using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace ApiComentarios.DataAccess.Configuretions
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User
            {
                Id= 1,
                Email = "admin@mail.com",
                Nombre = "Developer",
                Apellidos = "Senior",
                Rol = "Admin",
                Password = "password",
            });

            builder.HasData(new User
            {
                Id= 2,
                Email = "user@mail.com",
                Nombre = "Jhon",
                Apellidos = "Doe",
                Rol = "User",
                Password = "password",
            });

        }
    }
}
