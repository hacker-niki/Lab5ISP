using System.Linq.Expressions;
using Senko_253505.Domain.Abstractions;
using Senko_253505.Domain.Entities;

namespace Senko_253505.Persistence.Repository;

public class FakeTransportCompanyRepository : IRepository<TransportCompany>
{
    private readonly List<TransportCompany> _transportCompanies;

    public FakeTransportCompanyRepository()
    {
        _transportCompanies = new List<TransportCompany>();
        var company = new TransportCompany("Toyota", "Chin");
        company.Id = 1;
        _transportCompanies.Add(company);
        company = new TransportCompany("BYD", "China");
        company.Id = 2;
        _transportCompanies.Add(company);
    }

    public Task<TransportCompany> GetByIdAsync(int id, CancellationToken cancellationToken = default,
        params Expression<Func<TransportCompany, object>>[] includesProperties)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<TransportCompany>> ListAllAsync(CancellationToken cancellationToken = default)
    {
        return Task.Run(() => _transportCompanies as IReadOnlyList<TransportCompany>);
    }

    public Task<IReadOnlyList<TransportCompany>> ListAsync(Expression<Func<TransportCompany, bool>> filter,
        CancellationToken cancellationToken = default,
        params Expression<Func<TransportCompany, object>>[] includesProperties)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(TransportCompany entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(TransportCompany entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(TransportCompany entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<TransportCompany> FirstOrDefaultAsync(Expression<Func<TransportCompany, bool>> filter,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}