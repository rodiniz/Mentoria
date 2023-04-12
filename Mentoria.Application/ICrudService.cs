namespace Mentoria.Application;
using OneOf;

public interface ICrudService<T> {
    
    Task<OneOf<T, ValidationFailed>> Create(T obj);

    Task<OneOf<T, NotFound,ValidationFailed>> UpdateAsync(T obj);

    Task Delete(T obj);

    Task<T> GetAsync(int id);

    List<T> Get(int currentPage, int pageSize);

    int TotalCount();
}