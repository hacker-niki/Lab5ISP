using System.Linq.Expressions;
using Senko_253505.Domain.Abstractions;
using Senko_253505.Domain.Entities;

namespace Senko_253505.Persistence.Repository;

public class FakeCarRepository : IRepository<Car>
{
    private readonly List<Car> _cars;

    public FakeCarRepository()
    {
        _cars = new List<Car>();
        for (var i = 1; i <= 2; i++)
        for (var j = 0; j < 5; j++)
        {
            var tmp = new Car(new Vehicle { Horsepower = j * 90, Model = $"car {j}", Year = 2000 + j }, i);
            tmp.UpdateDate(new DateOnly(2020 + j, 1, 23));
            _cars.Add(tmp);
        }
    }

    public Task<Car> GetByIdAsync(int id, CancellationToken cancellationToken = default,
        params Expression<Func<Car, object>>[] includesProperties)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<Car>> ListAllAsync(CancellationToken cancellationToken = default)
    {
        return await Task.Run(() => _cars, cancellationToken);
    }

    public Task<IReadOnlyList<Car>> ListAsync(Expression<Func<Car, bool>> filter,
        CancellationToken cancellationToken = default,
        params Expression<Func<Car, object>>[] includesProperties)
    {
        return Task.Run(() => _cars as IReadOnlyList<Car>);
    }

    public Task AddAsync(Car entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Car entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Car entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Car> FirstOrDefaultAsync(Expression<Func<Car, bool>> filter,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}