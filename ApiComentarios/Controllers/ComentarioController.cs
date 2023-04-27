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
    /// <summary>
    /// Controlador de COmentarios, hereda de controlador base, proporciona metodos CRUD y listado con paginación
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : MyBaseController<Comments, ICommentService>
    {

        public CommentController(ICommentService service) : base(service)
        {
        }

        /// <summary>
        /// Lista los comentarios paginados
        /// </summary>
        /// <param name="paginacionDTO">Objeto Paginacion</param>
        /// <parm name="pageNumber">Número de la pagina</parm>
        /// <parm name="maxSizePage">Cantidad de elementos</parm>
        /// <response code="500">
        /// Error cases:<br />
        /// <ul>
        ///      <li><see cref="System.Exception"/>: Unknown Error</li>
        ///      <li><see cref="System.ArgumentException"/>: Si el identificador es inválido.</li>
        /// </ul>
        /// </response> 
        /// <response code="401">        
        /// Response error cases: <br />
        /// <ul>              
        ///      <li><see cref="System.UnauthorizedAccessException"/>: When the user is not authenticated or is not authorized to use this operation</li>
        /// </ul>
        /// </response>
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
        /// <param name="id">Identificador del Comentario en base de datos</param>
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
        /// <param name="commentDTO">Objeto Comentario, contiene los datos del comentario. Ver doc CommentDTO</param>
        /// <returns>Los datos del comentario</returns>
        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] CommentDTO commentDTO)
        {
            var comment = await _service.SaveComment(commentDTO);
            commentDTO.Id = comment.Id;

            return Created($"/{comment.Id}", commentDTO);
        }

        /// <summary>
        /// Actualiza un comentario. SOlo actualizara los objetos en updateComent. Ver doc UpdateComment
        /// </summary>
        /// <param name="updateComment">titulo, texto y la fecha de edición</param>
        /// <returns>No Content</returns>
        [HttpPut]
        public virtual async Task<IActionResult> Put([FromBody] CommentDTO updateComment)
        {
            await _service.SaveComment(updateComment);
            return NoContent();
        }

        /// <summary>
        /// Elimina un comentario utilizando su Id
        /// </summary>
        /// <param name="id">Id del comentario, requerido para encontrar el comentario que se desea eliminar</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteComment(id);

            return Ok(new { mensaje = "Comentario eliminado con exito!" });
        }
    }
}
