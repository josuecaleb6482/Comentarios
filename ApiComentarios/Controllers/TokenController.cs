using ApiComentarios.Entities.DTOs;
using ApiComentarios.Services.Auth;
using ApiComentarios.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using System.Threading.Tasks;

namespace ApiComentarios.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : MyBaseController<User, IUserServices>
    {
        private IConfiguration _configuration;

        public TokenController(IConfiguration configuration, IUserServices service) : base(service)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Autenticacion con usuario y contraseña
        /// </summary>
        /// <param name="usuarioLoginDTO"></param>
        /// <returns>JWT</returns>
        [HttpPost]
        public async Task<IActionResult> Authentication(UsuarioLoginDTO usuarioLoginDTO)
        {
            var userInfoDTO = await _service.Login(usuarioLoginDTO.usuario, usuarioLoginDTO.password);

            if (usuarioLoginDTO != null)
            {
                var jwt = new JwtServices(_configuration);

                var token = jwt.GenerateSecurityToken(userInfoDTO.Name, userInfoDTO.Email, userInfoDTO.Rol);
                return Ok(token);
            }

            return NotFound();
        }
    }
}