namespace Senko_253505.Application.CarsUseCases.Commands;

public class UpdateCarCommand : IAddOrUpdateCarCommand
{
    public Car Car { get; set; }
}