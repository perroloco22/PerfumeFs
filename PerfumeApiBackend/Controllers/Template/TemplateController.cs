using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfumeApiBackend.Models.DataModels;
using PerfumeApiBackend.Repository.Interfaces;

namespace PerfumeApiBackend.Controllers.Template
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class TemplateController<TEntity, TRepository> : ControllerBase
        where TEntity : BaseEntity
        where TRepository : IRepositoryGet<TEntity>, IRepositoryModify<TEntity>
    {
        protected readonly TRepository _repository;

        public TemplateController(TRepository repository)
        {
            _repository = repository;
        }

        
        [HttpGet]
        public virtual async Task<ActionResult<List<TEntity>>> GetAllAsync()
        {
            var lst = await _repository.GetAllAsync();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TEntity>> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpPost]
        public virtual async Task<ActionResult> AddAsync(TEntity entity)
        {
            var res = await _repository.AddAsync(entity);
            if (res is not null)
            {
                return Ok(res);
            }
            return Problem($"No se pudo agregar la {nameof(TEntity)}");
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<TEntity>> DeletedAsync(int id)
        {
            var response = await _repository.DeleteAsync(id);
            if (response is not null)
            {
                return Ok(response);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult> UpdateAsync(TEntity entity, int id)
        {

            if (entity.ID != id)
            {
                return BadRequest();
            }

            var response = await _repository.UpdateAsync(entity);

            if (response is not null)
            {
                return Ok();
            }

            return NotFound();

        }
    }
}
