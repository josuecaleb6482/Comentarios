using ApiComentarios.Abtractions;
using ApiComentarios.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiComentarios.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class MyBaseController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : IRepository<TEntity>
    {
        public readonly TRepository _repository;
        public MyBaseController(TRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<ComentarioController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listComentarios = await _repository.GetList();

                return Ok(listComentarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ComentarioController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var comentario = await _repository.GetById(id);
                if (comentario == null)
                {
                    return NotFound();
                }
                return Ok(comentario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ComentarioController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TEntity entity)
        {
            try
            {
                await _repository.Save(entity);

                return Created("/", entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ComentarioController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TEntity entity)
        {
            try
            {
                if (id != entity.id)
                {
                    return BadRequest(id);
                }
                await _repository.Save(entity);
                return Ok(new { mensaje = "Comentario actualizado con exito!" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ComentarioController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var entity = await _repository.GetById(id);

                if (entity == null)
                {
                    return NotFound(id);
                }
                await _repository.Delete(entity.id);

                return Ok(new { mensaje = "Comentario eliminado con exito!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
