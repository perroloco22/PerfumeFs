using Microsoft.EntityFrameworkCore;
using PerfumeApiBackend.Models.DataModels;
using PerfumeApiBackend.Repository.Interfaces;

namespace PerfumeApiBackend.Repository
{
    public class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        private readonly TContext _context;

        public Repository(TContext context )
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            IEnumerable<TEntity> lst = await (from entityes in _context.Set<TEntity>()
                                      select entityes).ToListAsync();
            return lst;
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity is null)
            {
                return null;
            }
            return entity;
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
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            return null;

        }

        public async Task<TEntity?> UpdateAsync(TEntity entity)
        {
            try
            { 
                var res = await _context.Set<TEntity>().FindAsync(entity.ID);
                if (res != null)
                {
                    _context.Entry(entity).State = EntityState.Modified;
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

    }
}
