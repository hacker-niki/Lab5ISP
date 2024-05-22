namespace Senko_253505.Application.CarsUseCases.Queries;

public sealed record GetCarByIdQuery(int Id) : IRequest<Car>
{
}