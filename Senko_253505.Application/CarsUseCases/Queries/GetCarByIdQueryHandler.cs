namespace Senko_253505.Application.CarsUseCases.Queries;

internal class GetCarByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetCarByIdQuery, Car>
{
    public async Task<Car> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork
            .CarRepository
            .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);
    }
}