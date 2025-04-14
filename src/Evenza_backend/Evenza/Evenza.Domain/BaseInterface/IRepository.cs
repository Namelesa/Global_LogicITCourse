namespace Evenza.Domain.BaseInterface;

public interface IRepository<T>
{
    Task<T> AddAsync(T t);
    Task<T> EditAsync(T t);
    Task<T> DeleteAsync(T t);
}