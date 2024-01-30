using CleanArchitecture.Application.CommandsAndQueries.Companies.Commands;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.CommandsAndQueries.Companies.Handlers;

public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, Company>
{
    private readonly ICompanyService _companyService;

    public DeleteCompanyCommandHandler(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    public async Task<Company> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyService.Delete(request.Id);
        return company;
    }
}
