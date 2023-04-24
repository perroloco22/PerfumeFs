namespace PerfumeApiBackend.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T?> DeleteAsync(int id);
        Task<T?> UpdateAsync(T entity);
        Task<T> AddAsync(T entity);

    }
}
