using ApiComentarios.DTOSs;
using ApiComentarios.Entities.DTOs;
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

    public class ComentarioController : MyBaseController<Comments, ICommentService>
    {

        public ComentarioController(ICommentService service) : base(service)
        {
        }

        /// <summary>
        /// Lista los comentarios y los pagina 
        /// </summary>
        /// <param name="paginacionDTO">Objeto Paginacion</param>
        /// <returns>Listado de comentarios</returns>
        [HttpGet]
        [Authorize(Policy = "RequireEditorRole")]
        public virtual async Task<IActionResult> Get([FromQuery] PaginacionDTO paginacionDTO)
        {
            ConfigurarPaginacion(paginacionDTO);

            var list = await _service.GetComments(paginacionDTO.pageNumber, paginacionDTO.maxItemsPage);

            return Ok(list);
        }

        /// <summary>
        /// Trae un comentario por Id
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Comentario individual</returns>
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            var comment = await _service.GetCommentById(id);
            return Ok(comment);
        }

        /// <summary>
        /// Crea un comentario con título
        /// </summary>
        /// <param name="commentDTO">Objeto Comentario</param>
        /// <returns>Los datos del comentario</returns>
        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] CommentDTO commentDTO)
        {
            var comment = await _service.SaveComment(commentDTO);

            return Created($"/{comment.Id}", commentDTO);
        }

        /// <summary>
        /// Actualiza un comentario
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="updateComment">Contiene el titulo y texto</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put(int id, [FromBody] CommentDTO updateComment)
        {
            await _service.SaveComment(updateComment, id);
            return NoContent();
        }

        /// <summary>
        /// Elimina un comentario
        /// </summary>
        /// <param name="id">Id del comentario</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteComment(id);

            return Ok(new { mensaje = "Comentario eliminado con exito!" });
        }
    }
}
