using ApiComentarios.Abtractions;
using ApiComentarios.Models;
using ApiComentarios.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiComentarios.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyBaseController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : IRepository<Comentario>
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
        public async Task<IActionResult> Post([FromBody] Comentario comentario)
        {
            try
            {
                await _repository.Save(comentario);

                return Ok(comentario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ComentarioController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Comentario comentario)
        {
            try
            {
                if (id != comentario.id)
                {
                    return BadRequest(id);
                }
                await _repository.Save(comentario);
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
                var comentario = await _repository.GetById(id);

                if (comentario == null)
                {
                    return NotFound(id);
                }
                _repository.Delete(comentario.id);

                return Ok(new { mensaje = "Comentario eliminado con exito!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
