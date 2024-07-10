using Infrastructure.Data;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly PokeContext _pokeContext;

    protected GenericRepository(PokeContext pokeContext)
    {
        _pokeContext = pokeContext ?? throw new ArgumentException(nameof(pokeContext));
    }

    public async Task<T> GetById(object id)
    {
        return await _pokeContext.Set<T>().FindAsync(id); 
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _pokeContext.Set<T>().ToListAsync();
    }

    public async Task Insert(T entity)
    {
        await _pokeContext.Set<T>().AddAsync(entity);
    }

    public void Delete(T entity)
    {
         _pokeContext.Set<T>().Remove(entity);
    }

    public void Update(T entity)
    {
         _pokeContext.Set<T>().Update(entity);
    }
}
