using ApiComentarios.WebApi.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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

        [HttpGet]
        public string GetToken(string email, string name, string role)
        {
            var jwt = new JwtServices(_configuration);

            return jwt.GenerateSecurityToken(email, name, role);
        }

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