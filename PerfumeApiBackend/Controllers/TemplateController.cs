using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfumeApiBackend.Models.DataModels;
using PerfumeApiBackend.Repository.Interfaces;

namespace PerfumeApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class TemplateController<TEntity, TRepository> : ControllerBase
        where TEntity : BaseEntity
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository _repository;

        public TemplateController(TRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TEntity>>> GetAllAsync()
        {
            var lst = await _repository.GetAllAsync();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(TEntity entity)
        {
            var respon = await _repository.AddAsync(entity);
            if (respon == entity)
            {
                return CreatedAtAction("GetById", new {id = entity.ID},respon);
            }
            return Problem($"No se pudo agregar la {nameof(TEntity)}");
        }

        [HttpDelete]
        public async Task<ActionResult<TEntity>> DeletedAsync(int id)
        {
            var response = await _repository.DeleteAsync(id);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();

        }

        [HttpPut("{id}")]
       public async Task<ActionResult> UpdateAsync(TEntity entity,int id)
       {

            if (entity.ID != id)
            {
                return BadRequest();
            }

            var response = await _repository.UpdateAsync(entity);

            if (response != null)
            {
                return Ok();
            }

            return NotFound();

       }
    }
}
