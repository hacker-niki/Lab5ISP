namespace Senko_253505.Application.CarsUseCases.Commands;

internal class UpdateArtistHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateCarCommand>
{
    public async Task Handle(UpdateCarCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.CarRepository.UpdateAsync(request.Car, cancellationToken);
        await unitOfWork.SaveAllAsync();
    }
}