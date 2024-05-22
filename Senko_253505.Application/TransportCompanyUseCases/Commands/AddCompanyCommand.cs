namespace Senko_253505.Application.TransportCompanyUseCases.Commands;

public sealed class AddCompanyCommand : IAddOrUpdateCompanyRequest
{
    public TransportCompany Company { get; set; }
}