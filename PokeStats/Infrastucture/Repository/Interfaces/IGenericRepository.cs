namespace Infrastructure.Repository.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(object id);
    Task Insert(T entity);
    void Update(T entity);
    void Delete(T entity);
}
