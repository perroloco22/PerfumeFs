using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerfumeApiBackend.Models.DataModels;
using PerfumeApiBackend.Repository.Interfaces;

namespace PerfumeApiBackend.Controllers.Template
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class TemplateGetController<TEntity,TRepository> : ControllerBase
        where TEntity : BaseEntity
        where TRepository : IRepositoryGet<TEntity>
    {
        protected readonly TRepository _repository;
        public TemplateGetController(TRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TEntity>>> GetAllAsync()
        {
            var lst = await _repository.GetAllAsync();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TEntity>> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }




    }
}
