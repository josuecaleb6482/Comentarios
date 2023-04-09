using ApiComentarios.Entities.DTOs;
using ApiComentarios.WebApi.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;

namespace ApiComentarios.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Genera un Token Valido
        /// </summary>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpGet]
        public string GetToken(string email, string name, string role)
        {
            var jwt = new JwtServices(_configuration);

            return jwt.GenerateSecurityToken(email, name, role);
        }
        /// <summary>
        /// Autenticacion con usuario y contraseña
        /// </summary>
        /// <param name="usuarioLoginDTO"></param>
        /// <returns>JWT</returns>
        [HttpPost]
        public IActionResult Authentication(UsuarioLoginDTO usuarioLoginDTO)
        {
            if (IsValidUser(usuarioLoginDTO))
            {
                UsuarioInfo usuario = new UsuarioInfo
                { Id = 1, Nombre = "Josue Florez", Rol = "Administrador", Email = "fake@mail.com" };

                var token = GetToken(usuario.Nombre + " " + usuario.Apellidos, usuario.Email, usuario.Rol);
                return Ok(token);
            }
            return NotFound();
        }

        private bool IsValidUser(UsuarioLoginDTO usuarioLoginDTO)
        {
            return true;
        }
    }
}