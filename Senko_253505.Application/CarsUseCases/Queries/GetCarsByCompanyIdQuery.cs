namespace Senko_253505.Application.CarsUseCases.Queries;

public sealed record GetCarsByCompanyIdQuery(int Id) : IRequest<IEnumerable<Car>>
{
}