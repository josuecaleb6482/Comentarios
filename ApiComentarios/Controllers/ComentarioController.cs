using ApiComentarios.Models;
using ApiComentarios.Services;
using ApiComentarios.WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiComentarios.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class ComentarioController : MyBaseController<Comentario, ComentariosServices>
    {
        public ComentarioController(ComentariosServices services) : base(services)
        {
        }

        public override async Task<IActionResult> Get()
        {
            // Validar que el usuario tiene permiso para agregar comentarios
            if (!User.HasClaim("permissions", "comment.create"))
            {
                return Forbid();
            }

            return await base.Get();
        }
    }
}
