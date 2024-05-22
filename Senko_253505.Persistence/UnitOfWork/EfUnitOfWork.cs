using Senko_253505.Domain.Abstractions;
using Senko_253505.Domain.Entities;
using Senko_253505.Persistence.Data;
using Senko_253505.Persistence.Repository;

namespace Senko_253505.Persistence.UnitOfWork;

public class EfUnitOfWork : IUnitOfWork
{
    private readonly Lazy<IRepository<Car>> _carRepository;
    private readonly AppDbContext _context;
    private readonly Lazy<IRepository<TransportCompany>> _transportCompanyRepository;

    public EfUnitOfWork(AppDbContext context)
    {
        _context = context;
        _carRepository = new Lazy<IRepository<Car>>(() =>
            new EfRepository<Car>(context));
        _transportCompanyRepository = new Lazy<IRepository<TransportCompany>>(() =>
            new EfRepository<TransportCompany>(context));
    }

    public IRepository<Car> CarRepository =>
        _carRepository.Value;

    public IRepository<TransportCompany> TransportCompanyRepository =>
        _transportCompanyRepository.Value;

    public async Task SaveAllAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task DeleteDataBaseAsync()
    {
        await _context.Database.EnsureDeletedAsync();
    }

    public async Task CreateDataBaseAsync()
    {
        await _context.Database.EnsureCreatedAsync();
    }
}