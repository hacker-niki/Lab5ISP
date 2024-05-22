namespace Senko_253505.Application.TransportCompanyUseCases.Commands;

internal class DeleteCompanyHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteCompanyCommand>
{
    public async Task Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.TransportCompanyRepository.DeleteAsync(request.Company, cancellationToken);
        await unitOfWork.SaveAllAsync();
    }
}