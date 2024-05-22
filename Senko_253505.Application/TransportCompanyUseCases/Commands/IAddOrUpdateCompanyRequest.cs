namespace Senko_253505.Application.TransportCompanyUseCases.Commands;

public interface IAddOrUpdateCompanyRequest : IRequest
{
    TransportCompany Company { get; set; }
}