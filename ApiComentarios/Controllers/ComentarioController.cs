using ApiComentarios.Abtractions.Interfaces;
using ApiComentarios.Entities.DTOs;
using ApiComentarios.Models;
using ApiComentarios.Repositories.Comments;
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

    public class ComentarioController : MyBaseController<Comentario, ICommentService>
    {
        public ComentarioController(ICommentService service) : base(service)
        {
        }

        // GET: api/<Entity>
        [HttpGet]
        public virtual async Task<IActionResult> Get([FromQuery] PaginacionDTO paginacionDTO)
        {
            ConfigurarPaginacion(paginacionDTO);

            var list = await _service.GetComments(paginacionDTO.pageNumber, paginacionDTO.maxItemsPage);
            //Respuesta 200
            return Ok(list);
        }

        //// GET api/<Entity>/5
        //[HttpGet("{id}")]
        //public virtual async Task<IActionResult> Get(int id)
        //{
        //    var entity = await _repository.GetById(id);
        //    if (entity == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(entity);
        //}

        //// POST api/<Entity>
        //[HttpPost]
        //public virtual async Task<IActionResult> Post([FromBody] TEntity entity)
        //{
        //    await _repository.Save(entity);

        //    return Created("/", entity);
        //}

        //// PUT api/<Entity>/5
        //[HttpPut("{id}")]
        //public virtual async Task<IActionResult> Put(int id, [FromBody] TEntity entity)
        //{
        //    if (id != entity.id)
        //    {
        //        return BadRequest(id);
        //    }
        //    await _repository.Save(entity);
        //    return Ok(new { mensaje = "Comentario actualizado con exito!" });
        //}

        //// DELETE api/<Entity>/5
        //[HttpDelete("{id}")]
        //public virtual async Task<IActionResult> Delete(int id)
        //{
        //    var entity = await _repository.GetById(id);

        //    if (entity == null)
        //    {
        //        return NotFound(id);
        //    }
        //    await _repository.Delete(entity.id);

        //    return Ok(new { mensaje = "Comentario eliminado con exito!" });
        //}
    }
}
