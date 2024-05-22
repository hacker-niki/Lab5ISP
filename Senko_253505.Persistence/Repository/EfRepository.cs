using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Senko_253505.Domain.Abstractions;
using Senko_253505.Domain.Entities;
using Senko_253505.Persistence.Data;

namespace Senko_253505.Persistence.Repository;

public class EfRepository<T> : IRepository<T> where T : Entity
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<T> _entities;

    public EfRepository(AppDbContext context)
    {
        _context = context;
        _entities = context.Set<T>();
    }

    public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includesProperties)
    {
        var query = _entities.AsQueryable();
        if (includesProperties is not null && includesProperties.Any())
            foreach (var included in includesProperties)
                query = query.Include(included);

        query.Where(e => e.Id == id);

        return await query.FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default)
    {
        return await _entities.ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<T>> ListAsync(
        Expression<Func<T, bool>>? filter,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includesProperties)
    {
        var query = _entities.AsQueryable();
        if (includesProperties.Any())
            foreach (var included in
                     includesProperties)
                query = query.Include(included);

        if (filter != null) query = query.Where(filter);

        return await query.ToListAsync();
    }

    public Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        _entities.Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(T entity,
        CancellationToken cancellationToken = default)
    {
        _context.Entry(entity).State = EntityState.Modified;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        _entities.Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken = default)
    {
        return await _entities.FirstOrDefaultAsync(filter, cancellationToken);
    }
}