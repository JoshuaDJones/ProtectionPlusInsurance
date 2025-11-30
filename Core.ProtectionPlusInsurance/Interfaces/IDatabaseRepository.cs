namespace Core.ProtectionPlusInsurance.Interfaces
{
    public interface IDatabaseRepository<T>
    {   
        Task<List<T>> GetListAsync(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default);
        Task<T?> GetByIdAsync(int id, CancellationToken ct = default);
        Task CreateAsync(T entity, CancellationToken ct = default);
        Task UpdateAsync(T entity, CancellationToken ct = default);
        Task DeleteAsync(int id, CancellationToken ct = default);
    }
}
