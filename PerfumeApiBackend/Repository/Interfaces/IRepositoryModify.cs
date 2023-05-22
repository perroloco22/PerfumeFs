namespace PerfumeApiBackend.Repository.Interfaces
{
    public interface IRepositoryModify<T> where T : class
    {
        Task<T?> DeleteAsync(int id);
        Task<T?> UpdateAsync(T entity);
        Task<T> AddAsync(T entity);
    }
}
