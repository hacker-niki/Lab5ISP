namespace Senko_253505.Application.CarsUseCases.Commands;

public sealed class AddCarCommand : IAddOrUpdateCarCommand
{
    public Car Car { get; set; }
}