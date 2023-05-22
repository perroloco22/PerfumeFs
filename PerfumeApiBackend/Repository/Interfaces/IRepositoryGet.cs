namespace PerfumeApiBackend.Repository.Interfaces
{
    public interface IRepositoryGet<T>  where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
    }
}
