namespace CoffeeShopSystem.Services.Interfaces
{
    public interface IAsyncRepository <T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetALlAsync();
        Task<T> AddAsync(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
    }
}
