namespace Senko_253505.Application.CarsUseCases.Commands;

public interface IAddOrUpdateCarCommand : IRequest
{
    Car Car { get; set; }
}