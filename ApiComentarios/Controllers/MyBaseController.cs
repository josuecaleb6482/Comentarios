using ApiComentarios.Abtractions;
using ApiComentarios.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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

        // GET: api/<Entity>
        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            var list = await _repository.GetList();
            //Respuesta 200
            return Ok(list);
        }

        // GET api/<Entity>/5
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            var entity = await _repository.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        // POST api/<Entity>
        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TEntity entity)
        {
            await _repository.Save(entity);

            return Created("/", entity);
        }

        // PUT api/<Entity>/5
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put(int id, [FromBody] TEntity entity)
        {
            if (id != entity.id)
            {
                return BadRequest(id);
            }
            await _repository.Save(entity);
            return Ok(new { mensaje = "Comentario actualizado con exito!" });
        }

        // DELETE api/<Entity>/5
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var entity = await _repository.GetById(id);

            if (entity == null)
            {
                return NotFound(id);
            }
            await _repository.Delete(entity.id);

            return Ok(new { mensaje = "Comentario eliminado con exito!" });
        }
    }
}
