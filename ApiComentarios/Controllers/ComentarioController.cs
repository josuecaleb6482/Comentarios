using ApiComentarios.DTOSs;
using ApiComentarios.Entities.DTOs;
using ApiComentarios.Models;
using ApiComentarios.Services;
using ApiComentarios.WebApi.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiComentarios.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class ComentarioController : MyBaseController<Comments, ICommentService>
    {
        private readonly IMapper _mapper;
        public ComentarioController(ICommentService service, IMapper mapper) : base(service)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Lista los comentarios y los pagina 
        /// </summary>
        /// <param name="paginacionDTO"></param>
        /// <returns>Listado de comentarios</returns>
        [HttpGet]
        [Authorize(Policy = "RequireEditorRole")]
        public virtual async Task<IActionResult> Get([FromQuery] PaginacionDTO paginacionDTO)
        {
            ConfigurarPaginacion(paginacionDTO);

            var list = await _service.GetComments(paginacionDTO.pageNumber, paginacionDTO.maxItemsPage);
            //Respuesta 200
            return Ok(list);
        }

        /// <summary>
        /// Trae un comentario por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Comentario individual</returns>
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            var entity = await _service.GetCommentById(id);

            if (entity == null)
            {
                return NotFound(new 
                {
                    message = "Comentario no encontrado",
                });
            }
            return Ok(entity);
        }

        /// <summary>
        /// Crea un comentario con titulo
        /// </summary>
        /// <param name="commentDTO"></param>
        /// <returns>Los datos del comentario</returns>
        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] ComentarioDTO commentDTO)
        {
            var comment = _mapper.Map<Comments>(commentDTO);
            await _service.SaveComment(comment);

            return Created($"/{comment.Id}", commentDTO);
        }

        /// <summary>
        /// Actualiza un comentario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateComment">Contiene el titulo y texto</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put(int id, [FromBody] UpdateCommentDTO updateComment)
        {
            var comment = await _service.GetCommentById(id);

            if (comment == null)
            {
                return NotFound(new { mensaje = "No existe el comentario", });
            }

            comment.Titulo = updateComment.Titulo ?? comment.Titulo;
            comment.Texto = updateComment.Texto ?? comment.Texto;

            await _service.SaveComment(comment);

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
            var comment = await _service.GetCommentById(id);

            if (comment == null)
            {
                return NotFound(id);
            }
            await _service.DeleteComment(comment.Id);

            return Ok(new { mensaje = "Comentario eliminado con exito!" });
        }
    }
}
