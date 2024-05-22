namespace Senko_253505.Application.CarsUseCases.Queries;

internal class GetCarsByCompanyIdHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetCarsByCompanyIdQuery, IEnumerable<Car>>

{
    public async Task<IEnumerable<Car>> Handle(GetCarsByCompanyIdQuery request, CancellationToken cancellationToken)
    {
        var a = await unitOfWork
            .CarRepository
            .ListAsync(s =>
                    s.TransportCompanyId.Equals(request.Id),
                cancellationToken);
        return a.Where(s => s.TransportCompanyId == request.Id);
    }
}