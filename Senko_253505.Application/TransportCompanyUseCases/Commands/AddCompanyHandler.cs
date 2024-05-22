namespace Senko_253505.Application.TransportCompanyUseCases.Commands;

internal class AddCompanyHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddCompanyCommand>
{
    public async Task Handle(AddCompanyCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.TransportCompanyRepository.AddAsync(request.Company, cancellationToken);
        await unitOfWork.SaveAllAsync();
    }
}