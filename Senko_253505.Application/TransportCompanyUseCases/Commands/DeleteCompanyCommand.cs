namespace Senko_253505.Application.TransportCompanyUseCases.Commands;

public sealed record DeleteCompanyCommand(TransportCompany Company) : IRequest
{
}