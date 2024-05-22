namespace Senko_253505.Application.TransportCompanyUseCases.Queries;

internal class GetCompaniesByGroupRequestHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetCompaniesQuery, IEnumerable<TransportCompany>>
{
    public async Task<IEnumerable<TransportCompany>> Handle(GetCompaniesQuery request,
        CancellationToken cancellationToken)
    {
        return await unitOfWork.TransportCompanyRepository.ListAllAsync(cancellationToken);
    }
}