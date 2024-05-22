using Microsoft.EntityFrameworkCore;
using Senko_253505.Domain.Abstractions;
using Senko_253505.Persistence.Data;
using Senko_253505.Persistence.UnitOfWork;

namespace Senko_253505.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddSingleton<IUnitOfWork, EfUnitOfWork>();
        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services, DbContextOptions options)
    {
        services.AddPersistence().AddSingleton(new AppDbContext((DbContextOptions<AppDbContext>)options));
        return services;
    }
}