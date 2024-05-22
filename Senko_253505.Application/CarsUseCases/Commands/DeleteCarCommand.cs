namespace Senko_253505.Application.CarsUseCases.Commands;

public sealed record DeleteCarCommand(Car Car) : IRequest
{
}