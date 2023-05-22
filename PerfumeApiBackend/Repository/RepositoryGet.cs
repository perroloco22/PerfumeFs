using Microsoft.EntityFrameworkCore;
using PerfumeApiBackend.Models.DataModels;
using PerfumeApiBackend.Repository.Interfaces;

namespace PerfumeApiBackend.Repository
{
    public abstract class RepositoryGet<TEntity, TContext> : IRepositoryGet<TEntity> 
        where TEntity : BaseEntity
        where TContext : DbContext
    {

        private readonly DbContext _context;

        protected RepositoryGet(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                var lst = await (from entity in _context.Set<TEntity>()
                                 select entity).ToListAsync();
                return lst;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(ent => ent.ID == id);
                return entity;

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
