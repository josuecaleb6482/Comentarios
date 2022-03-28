using ApiComentarios.Models;
using ApiComentarios.Services;
using ApiComentarios.WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
    }
}
