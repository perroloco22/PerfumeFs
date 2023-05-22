using Microsoft.EntityFrameworkCore;
using PerfumeApiBackend.Models.DataModels;
using PerfumeApiBackend.Repository.Interfaces;

namespace PerfumeApiBackend.Repository
{
    public abstract class RepositoryModify<TEntity,TContext> : IRepositoryModify<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        private readonly TContext _context;
        public RepositoryModify(TContext context)
        {
            _context = context;            
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                await _context.SaveChangesAsync();
                return entity;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TEntity?> DeleteAsync(int id)
        {
            try
            {
                var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(ent => ent.ID ==id);
                if (entity is not null) 
                {
                    _context.Remove(entity);
                    await _context.SaveChangesAsync();
                    return entity;
                }
                return null;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<TEntity?> UpdateAsync(TEntity entity)
        {
            try
            {
                var existEntity = await _context.Set<TEntity>().AnyAsync(ent => ent.ID == entity.ID);
                if (!existEntity) return null;
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return entity;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
