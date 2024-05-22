namespace Senko_253505.Application.CarsUseCases.Commands;

internal class AddCarHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddCarCommand>
{
    public async Task Handle(AddCarCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.CarRepository.AddAsync(request.Car, cancellationToken);
        await unitOfWork.SaveAllAsync();
    }
}