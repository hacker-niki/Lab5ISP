using Senko_253505.Domain.Abstractions;
using Senko_253505.Domain.Entities;
using Senko_253505.Persistence.Repository;

namespace Senko_253505.Persistence.UnitOfWork;

public class FakeUnitOfWork : IUnitOfWork
{
    private readonly FakeCarRepository _carRepository;
    private readonly FakeTransportCompanyRepository _transportCompanyRepository;

    public FakeUnitOfWork()
    {
        _carRepository = new FakeCarRepository();
        _transportCompanyRepository = new FakeTransportCompanyRepository();
    }

    public IRepository<Car> CarRepository => _carRepository;
    public IRepository<TransportCompany> TransportCompanyRepository => _transportCompanyRepository;

    public Task SaveAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task DeleteDataBaseAsync()
    {
        throw new NotImplementedException();
    }

    public Task CreateDataBaseAsync()
    {
        throw new NotImplementedException();
    }
}