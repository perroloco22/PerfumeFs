using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerfumeApiBackend.Models.DataModels;
using PerfumeApiBackend.Repository.Interfaces;

namespace PerfumeApiBackend.Controllers.Template
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class TemplateModifyController<TEntity, TRepository> : ControllerBase
        where TEntity : BaseEntity
        where TRepository : IRepositoryModify<TEntity>
    {
        protected readonly TRepository _repository;

        public TemplateModifyController( TRepository repository)
        {
            _repository = repository;
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

        [HttpPut("{id}")]
        public virtual async Task<ActionResult> UpdateAsync(TEntity entity, int id)
        {
            if (entity.ID != id)
            {
                return BadRequest();
            }

            var res = await _repository.UpdateAsync(entity);

            if (res is not null)
            {
                return Ok();
            }

            return NotFound();


        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<TEntity>> DeleteAsync(int id)
        {
            var res = await _repository.DeleteAsync(id);
            if (res is not null)
            {
                return Ok(res);
            }
            return BadRequest();
        }

    }
}
