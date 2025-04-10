using Blog.api.Domain.Interfaces.Common;
using Blog.api.Domain.Models.Common;
using System.Linq.Expressions;

namespace Blog.api.Infrastructure.Repositories.Common;

public class InMemoryRepository<TEntity, TId>: IRepository<TEntity, TId>
    where TEntity : BaseEntity<TId>
    where TId : notnull
{
    private readonly List<TEntity> _entities = new();
    private readonly object _lock = new();

    public InMemoryRepository() { }

    public InMemoryRepository(List<TEntity> entitiesList)
    {
        _entities.AddRange(entitiesList);
    }

    public async Task<TEntity?> GetByIdAsync(TId id)
    {
        return await Task.FromResult(_entities.FirstOrDefault(e => e.Id.Equals(id)));
    }

    public  IEnumerable<TEntity> GetAll()
    {
        return _entities.AsQueryable();
    }

    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var compiledPredicate = predicate.Compile();
        return await Task.FromResult(_entities.Where(compiledPredicate));
    }

    public async Task AddAsync(TEntity entity)
    {
        lock (_lock)
        {
            _entities.Add(entity);
        }
        await Task.CompletedTask;
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        lock (_lock)
        {
            _entities.AddRange(entities);
        }
        await Task.CompletedTask;
    }

    public async Task UpdateAsync(TEntity entity)
    {
        lock (_lock)
        {
            var index = _entities.FindIndex(e => e.Id.Equals(entity.Id));
            if (index >= 0)
            {
                _entities[index] = entity;
            }
        }
        await Task.CompletedTask;
    }

    public async Task RemoveAsync(TEntity entity)
    {
        lock (_lock)
        {
            _entities.RemoveAll(e => e.Id.Equals(entity.Id));
        }
        await Task.CompletedTask;
    }

    public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
    {
        lock (_lock)
        {
            var idsToRemove = entities.Select(e => e.Id).ToHashSet();
            _entities.RemoveAll(e => idsToRemove.Contains(e.Id));
        }
        await Task.CompletedTask;
    }

    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var compiledPredicate = predicate.Compile();
        return await Task.FromResult(_entities.Any(compiledPredicate));
    }

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null)
    {
        if (predicate == null)
            return await Task.FromResult(_entities.Count);

        var compiledPredicate = predicate.Compile();
        return await Task.FromResult(_entities.Count(compiledPredicate));
    }

    public async Task<(IEnumerable<TEntity> Items, int TotalCount)> GetPagedAsync(
        int pageNumber,
        int pageSize,
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
    {
        IEnumerable<TEntity> query = _entities;

        if (predicate != null)
        {
            var compiledPredicate = predicate.Compile();
            query = query.Where(compiledPredicate);
        }

        var totalCount = query.Count();

        if (orderBy != null)
        {
            query = orderBy(query.AsQueryable()).AsEnumerable();
        }

        var items = query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return await Task.FromResult((items, totalCount));
    }
}