namespace Senko_253505.Application.CarsUseCases.Commands;

internal class DeleteCarHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteCarCommand>
{
    public async Task Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.CarRepository.DeleteAsync(request.Car, cancellationToken);
        await unitOfWork.SaveAllAsync();
    }
}