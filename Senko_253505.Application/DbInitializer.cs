namespace Senko_253505.Application;

public static class DbInitializer
{
    public static async Task Initialize(IServiceProvider services)
    {
        var unitOfWork = services.GetRequiredService<IUnitOfWork>();

        await unitOfWork.DeleteDataBaseAsync();
        await unitOfWork.CreateDataBaseAsync();

        IReadOnlyList<TransportCompany> transportCompanies = new List<TransportCompany>()
        {
            new() { Name = "Tesla", Owner = "Mask" },
            new() { Name = "Toyota", Owner = "HZ" },
            new() { Name = "BYD", Owner = "Ching chang" },
        };

        foreach (var company in transportCompanies)
            await unitOfWork.TransportCompanyRepository.AddAsync(company);

        await unitOfWork.SaveAllAsync();

        var counter = 1;
        foreach (var company in transportCompanies)
        {
            for (int j = 0; j < 6; j++)
            {
                await unitOfWork.CarRepository.AddAsync(new()
                {
                    Name = $"CAR {j}",
                    Characteristic = new() { Horsepower = 50 + j * 100, Model = $"car {j}", Year = 1999 + j * 5 },
                    TransportCompanyId = counter,
                    Date = DateOnly.FromDateTime(DateTime.Now - TimeSpan.FromDays(j * 365))
                });
            }

            counter++;
        }

        await unitOfWork.SaveAllAsync();
    }
}