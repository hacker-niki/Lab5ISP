using Senko_253505.Domain.Entities;

namespace Senko_253505.Domain.Abstractions;

public interface IUnitOfWork
{
    IRepository<Car> CarRepository { get; }
    IRepository<TransportCompany> TransportCompanyRepository { get; }
    public Task SaveAllAsync();
    public Task DeleteDataBaseAsync();
    public Task CreateDataBaseAsync();
}