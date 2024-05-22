namespace Senko_253505.Application.TransportCompanyUseCases.Commands;

public class UpdateCompanyCommand : IAddOrUpdateCompanyRequest
{
    public TransportCompany Company { get; set; }
}