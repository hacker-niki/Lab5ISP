namespace Senko_253505.Application.TransportCompanyUseCases.Commands;

internal class UpdateCompanyHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateCompanyCommand>
{
    public async Task Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.TransportCompanyRepository.UpdateAsync(request.Company, cancellationToken);
        await unitOfWork.SaveAllAsync();
    }
}